#!/bin/bash

# Post-create script for OpenLanguage development container
set -e

echo "🚀 Setting up OpenLanguage development environment..."

# Update package lists
sudo apt-get update

# Install additional development tools
sudo apt-get install -y
build-essential
gcc
g++
make
cmake
git
curl
wget
unzip
tree
jq
vim
nano

# Install .NET SDK (latest version)
echo "📦 Installing .NET SDK..."
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-9.0

# Restore .NET tools
echo "🔧 Restoring .NET tools..."
dotnet tool restore

# Restore NuGet packages
echo "📦 Restoring NuGet packages..."
dotnet restore

# Configure Git (if not already configured)
if [ -z "$(git config --global user.name)" ]; then
  echo "⚙️  Configuring Git..."
  git config --global user.name "Development Container User"
  git config --global user.email "dev@openlanguage.dev"
  git config --global init.defaultBranch main
  git config --global pull.rebase false
fi

# Set up CMake build directory
echo "🏗️  Setting up CMake build system..."
mkdir -p build
cd build
cmake ..
cd ..

# Install git hooks
echo "🪝 Installing git hooks..."
cmake --build build --target install-hooks

# Run initial build to verify everything works
echo "🔨 Running initial build..."
cmake --build build --target process
cmake --build build --target build

# Run tests to verify setup
echo "🧪 Running tests..."
cmake --build build --target test

# Format code
echo "💅 Formatting code..."
cmake --build build --target format

echo "✅ Development environment setup complete!"
echo ""
echo "🎯 Available CMake targets:"
echo "  - process: Process .y/.lex files"
echo "  - build: Build the solution"
echo "  - test: Run unit tests"
echo "  - format: Format code with CSharpier"
echo "  - doc: Generate documentation"
echo "  - publish: Package for NuGet"
echo "  - clean-all: Clean build artifacts"
echo ""
echo "🚀 Ready for development!"
