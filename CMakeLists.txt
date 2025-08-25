cmake_minimum_required(VERSION 3.20)
project(OpenLanguage)

# --- RID Detection and Configuration ---

# Detect the architecture
if(CMAKE_SYSTEM_PROCESSOR MATCHES "^(x86_64|AMD64)$")
  set(DETECTED_ARCH "x64")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^(aarch64|arm64)$")
  set(DETECTED_ARCH "arm64")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^(i[3-6]86|x86)$")
  set(DETECTED_ARCH "x86")
else()
  set(DETECTED_ARCH ${CMAKE_SYSTEM_PROCESSOR})
endif()

# Detect the OS
if(CMAKE_SYSTEM_NAME STREQUAL "Linux")
  set(DETECTED_OS "linux")
elseif(CMAKE_SYSTEM_NAME STREQUAL "Darwin")
  set(DETECTED_OS "osx")
elseif(CMAKE_SYSTEM_NAME STREQUAL "Windows")
  set(DETECTED_OS "win")
elseif(CMAKE_SYSTEM_NAME STREQUAL "FreeBSD")
  set(DETECTED_OS "freebsd")
endif()

# Combine to form the RID, if possible
if(DEFINED DETECTED_OS AND DEFINED DETECTED_ARCH)
  set(DETECTED_RID "${DETECTED_OS}-${DETECTED_ARCH}")
  message(STATUS "Detected .NET Runtime Identifier (RID): ${DETECTED_RID}")
else()
  message(WARNING "Could not automatically determine .NET RID. You must specify it with -D RUNTIMES=...")
  set(DETECTED_RID "")
endif()

# Allow user to override the RIDs. Defaults to the detected RID.
set(RUNTIMES "${DETECTED_RID}" CACHE STRING "Semicolon-separated list of .NET RIDs for AOT compilation.")
message(STATUS "Configured to build for RIDs: ${RUNTIMES}")

# --- Project Variables ---
set(SOLUTION_FILE "${CMAKE_SOURCE_DIR}/OpenLanguage.sln")
set(PROJECT_DIR "${CMAKE_SOURCE_DIR}/OpenLanguage")
set(GENERATED_DIR "${PROJECT_DIR}/Generated")
set(TEST_PROJECT_DIR "${CMAKE_SOURCE_DIR}/OpenLanguage.Test")

file (GLOB_RECURSE PROJECT_LIST "${PROJECT_DIR}/*.csproj")

# --- File Pre-processing ---
# Find all .y and .lex files
file(GLOB_RECURSE YACC_FILES "${PROJECT_DIR}/**/*.y")
file(GLOB_RECURSE LEX_FILES "${PROJECT_DIR}/**/*.lex")

# Exclude files that are already in the Generated directory to avoid reprocessing.
list(FILTER YACC_FILES EXCLUDE REGEX ^${GENERATED_DIR})
list(FILTER LEX_FILES EXCLUDE REGEX ^${GENERATED_DIR})

# Custom target to process .y and .lex files
add_custom_target(process ALL
    COMMENT "Processing .y and .lex files with cpp"
)

# Create Generated directory
add_custom_command(
    TARGET process PRE_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${GENERATED_DIR}
    COMMENT "Creating Generated directory"
)

# Process .y files
foreach(YACC_FILE ${YACC_FILES})
  file(RELATIVE_PATH REL_PATH ${PROJECT_DIR} ${YACC_FILE})
  get_filename_component(REL_DIR ${REL_PATH} DIRECTORY)
  get_filename_component(FILENAME ${YACC_FILE} NAME)
  set(OUTPUT_DIR "${GENERATED_DIR}/${REL_DIR}")
  set(OUTPUT_FILE "${OUTPUT_DIR}/${FILENAME}")

  add_custom_command(
        TARGET process PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E make_directory ${OUTPUT_DIR}
        COMMAND cpp -P ${YACC_FILE} -o ${OUTPUT_FILE} -Wno-invalid-pp-token
        COMMENT "Processing ${YACC_FILE} -> ${OUTPUT_FILE}"
    )
endforeach()

# Process .lex files
foreach(LEX_FILE ${LEX_FILES})
  file(RELATIVE_PATH REL_PATH ${PROJECT_DIR} ${LEX_FILE})
  get_filename_component(REL_DIR ${REL_PATH} DIRECTORY)
  get_filename_component(FILENAME ${LEX_FILE} NAME)
  set(OUTPUT_DIR "${GENERATED_DIR}/${REL_DIR}")
  set(OUTPUT_FILE "${OUTPUT_DIR}/${FILENAME}")

  add_custom_command(
        TARGET process PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E make_directory ${OUTPUT_DIR}
        COMMAND cpp -P ${LEX_FILE} -o ${OUTPUT_FILE} -Wno-invalid-pp-token
        COMMENT "Processing ${LEX_FILE} -> ${OUTPUT_FILE}"
    )
endforeach()

# --- Main Build Targets ---

add_custom_target(build
    COMMENT "Building solution for specified RIDs"
)

# Create a separate build target for each RID for concurrent compilation
string(REPLACE ";" " " RUNTIMES_LIST "${RUNTIMES}")
foreach (PROJECT ${PROJECT_LIST})
  get_filename_component(PROJECT_NAME ${PROJECT} NAME_WE)
  foreach(RID ${RUNTIMES_LIST})
    if(NOT RID)
      continue() # Skip if the RID list is empty
    endif()

    # Sanitize the RID to create a valid CMake target name (e.g., win-x64 -> win_x64)
    string(REPLACE "-" "_" RID_SAFE ${RID})
    set(RID_TARGET_NAME "build_${PROJECT_NAME}_${RID_SAFE}")

    add_custom_target(${RID_TARGET_NAME}
        COMMAND dotnet publish ${PROJECT}
                --configuration Release
                -r ${RID}
                # CMAKE_BINARY_DIR/PROJECT_NAME/publish/RID
                --property:OutputPath="${CMAKE_BINARY_DIR}/publish/${PROJECT_NAME}/${RID}"
                --artifacts-path "${CMAKE_BINARY_DIR}/artifacts/${PROJECT_NAME}/${RID}"
        WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}
        COMMENT "Building and publishing for RID: ${RID}"
        VERBATIM
    )
    # Make the main 'build' target depend on this one
    add_dependencies(build ${RID_TARGET_NAME})
    add_dependencies(${RID_TARGET_NAME} process)
  endforeach()
endforeach()

# --- Other Utility Targets ---

add_custom_target(tool_restore
    COMMAND dotnet tool restore --verbosity q
    COMMENT "Restoring dotnet tools"
)



# Test target - dependent on build
add_custom_target(test
    COMMAND dotnet test "${TEST_PROJECT_DIR}/OpenLanguage.Test.csproj" --configuration Release --no-build --verbosity normal
    DEPENDS build
    COMMENT "Running unit tests"
)

# Publish target - dependent on build
add_custom_target(publish
    COMMAND dotnet pack ${PROJECT_DIR}/OpenLanguage.csproj --configuration Release --property:OutputPath="${CMAKE_BINARY_DIR}/packages" --no-build
    COMMAND echo "Ready to publish to NuGet. Run: dotnet nuget push ${CMAKE_BINARY_DIR}/packages/*.nupkg --source https://api.nuget.org/v3/index.json"
    DEPENDS build
    COMMENT "Packaging for NuGet publication"
)

# Format target
add_custom_target(format
    DEPENDS tool_restore
    COMMAND dotnet csharpier format ${CMAKE_SOURCE_DIR}
    COMMENT "Formatting code with CSharpier"
)

# Documentation target - dependent on build
add_custom_target(doc
    DEPENDS build tool_restore
    COMMAND dotnet docfx metadata "${CMAKE_SOURCE_DIR}/docfx/docfx.json"
    COMMAND dotnet docfx build "${CMAKE_SOURCE_DIR}/docfx/docfx.json"
    WORKING_DIRECTORY "${CMAKE_SOURCE_DIR}/docfx"
    COMMENT "Generating API documentation with DocFX"
)

# Install git hooks target
add_custom_target(install-hooks
    COMMAND ${CMAKE_COMMAND} -E copy_if_different
        ${CMAKE_SOURCE_DIR}/hooks/pre-commit
        ${CMAKE_SOURCE_DIR}/.git/hooks/pre-commit
    COMMAND chmod +x ${CMAKE_SOURCE_DIR}/.git/hooks/pre-commit
    COMMENT "Installing git hooks"
)

# Clean target
add_custom_target(clean-all
    COMMAND "${CMAKE_COMMAND}" -E remove_directory "${CMAKE_BINARY_DIR}"
    COMMAND "${CMAKE_COMMAND}" -E remove_directory "${GENERATED_DIR}"
    COMMAND find "${CMAKE_SOURCE_DIR}" -name "obj" -type d -exec rm -rf {} + || true
    COMMAND find "${CMAKE_SOURCE_DIR}" -name "bin" -type d -exec rm -rf {} + || true
    COMMENT "Cleaning all build artifacts"
)

# Default target
add_custom_target(default ALL DEPENDS process build)
