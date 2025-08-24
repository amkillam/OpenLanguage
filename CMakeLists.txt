cmake_minimum_required(VERSION 3.20)
project(OpenLanguage)

# Set variables
set(SOLUTION_FILE "${CMAKE_SOURCE_DIR}/OpenLanguage.sln")
set(PROJECT_DIR "${CMAKE_SOURCE_DIR}/OpenLanguage")
set(GENERATED_DIR "${PROJECT_DIR}/Generated")
set(TEST_PROJECT_DIR "${CMAKE_SOURCE_DIR}/OpenLanguage.Test")

# Find all .y and .lex files
file(GLOB_RECURSE YACC_FILES "${PROJECT_DIR}/**/*.y")
file(GLOB_RECURSE LEX_FILES "${PROJECT_DIR}/**/*.lex")

# Exclude files that are already in the Generated directory to avoid reprocessing.
# The regex "^${GENERATED_DIR}" matches any path that *starts with* the Generated directory's path.
list(FILTER YACC_FILES EXCLUDE REGEX "^${GENERATED_DIR}")
list(FILTER LEX_FILES EXCLUDE REGEX "^${GENERATED_DIR}")

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
  # Get relative path from OpenLanguage directory
  file(RELATIVE_PATH REL_PATH ${PROJECT_DIR} ${YACC_FILE})
  get_filename_component(REL_DIR ${REL_PATH} DIRECTORY)
  get_filename_component(FILENAME ${YACC_FILE} NAME)

  # Create output directory structure
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
  # Get relative path from OpenLanguage directory
  file(RELATIVE_PATH REL_PATH ${PROJECT_DIR} ${LEX_FILE})
  get_filename_component(REL_DIR ${REL_PATH} DIRECTORY)
  get_filename_component(FILENAME ${LEX_FILE} NAME)

  # Create output directory structure
  set(OUTPUT_DIR "${GENERATED_DIR}/${REL_DIR}")
  set(OUTPUT_FILE "${OUTPUT_DIR}/${FILENAME}")

  add_custom_command(
        TARGET process PRE_BUILD
        COMMAND ${CMAKE_COMMAND} -E make_directory ${OUTPUT_DIR}
        COMMAND cpp -P ${LEX_FILE} -o ${OUTPUT_FILE} -Wno-invalid-pp-token
        COMMENT "Processing ${LEX_FILE} -> ${OUTPUT_FILE}"
    )
endforeach()

# Build target - dependent on process
add_custom_target(build
    COMMAND dotnet publish ${SOLUTION_FILE} --configuration Release --output ${CMAKE_BINARY_DIR}/publish
    WORKING_DIRECTORY ${PROJECT_DIR}
    DEPENDS process
    COMMENT "Building and publishing OpenLanguage solution"
)

# Test target - dependent on build
add_custom_target(test
    COMMAND dotnet test ${SOLUTION_FILE} --configuration Release --no-build --verbosity normal
    DEPENDS build
    COMMENT "Running unit tests"
)

# Publish target - dependent on build
add_custom_target(publish
    COMMAND dotnet pack ${PROJECT_DIR}/OpenLanguage.csproj --configuration Release --output ${CMAKE_BINARY_DIR}/packages --no-build
    COMMAND echo "Ready to publish to NuGet. Run: dotnet nuget push ${CMAKE_BINARY_DIR}/packages/*.nupkg --source https://api.nuget.org/v3/index.json"
    DEPENDS build
    COMMENT "Packaging for NuGet publication"
)

# Format target
add_custom_target(format
    COMMAND dotnet csharpier ${CMAKE_SOURCE_DIR}
    COMMENT "Formatting code with CSharpier"
)

# Documentation target - dependent on build
add_custom_target(doc
    COMMAND dotnet tool install --global docfx || echo "DocFX already installed"
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_BINARY_DIR}/docs
    COMMAND docfx init -q -o ${CMAKE_BINARY_DIR}/docs || echo "DocFX project exists"
    COMMAND docfx metadata ${CMAKE_BINARY_DIR}/docs/docfx_project/docfx.json
    COMMAND docfx build ${CMAKE_BINARY_DIR}/docs/docfx_project/docfx.json -o ${CMAKE_BINARY_DIR}/docs/site
    DEPENDS build
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
    COMMAND ${CMAKE_COMMAND} -E remove_directory ${CMAKE_BINARY_DIR}
    COMMAND ${CMAKE_COMMAND} -E remove_directory ${GENERATED_DIR}
    COMMAND find ${CMAKE_SOURCE_DIR} -name "obj" -type d -exec rm -rf {} + || true
    COMMAND find ${CMAKE_SOURCE_DIR} -name "bin" -type d -exec rm -rf {} + || true
    COMMENT "Cleaning all build artifacts"
)

# Default target
add_custom_target(default ALL DEPENDS process)
