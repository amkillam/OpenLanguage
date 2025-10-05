# OpenLanguage Development Container

This directory contains the development container configuration for OpenLanguage, providing a consistent development environment across different machines and platforms.

## Features

### 🛠️ Development Tools

- **.NET 8.0 & 9.0 SDKs**: For targeting multiple runtimes
- **CMake 3.20+**: Build system for cross-platform builds
- **Git**: Version control with pre-configured hooks using Husky
- **GitHub CLI**: GitHub integration for issues, PRs, and releases

### 🗄️ Database Support

- **SQL Server ODBC Driver**: Microsoft SQL Server connectivity
- **MySQL ODBC Driver**: MySQL database integration
- **PostgreSQL ODBC Driver**: PostgreSQL support
- **ODBC Tools**: UnixODBC for database connectivity testing

### 🧩 VS Code Extensions

- **C# Dev Kit**: Complete C# development experience
- **CMake Tools**: CMake integration and IntelliSense
- **GitHub Copilot**: AI-powered code assistance
- **Markdown Support**: Documentation editing and preview
- **Path IntelliSense**: File path autocompletion

### 🐳 Docker Services (Compose)

- **SQL Server 2022**: For testing ODBC functionality
- **MySQL 8.0**: Alternative database testing
- **PostgreSQL 16**: Advanced database features
- **Redis 7**: Caching scenarios

## Quick Start

### Using VS Code Dev Containers

1. **Prerequisites**:

   - [VS Code](https://code.visualstudio.com/)
   - [Dev Containers Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.remote-containers)
   - [Docker Desktop](https://www.docker.com/products/docker-desktop/)

2. **Open in Container**:

   - Open the project in VS Code
   - Press `Ctrl+Shift+P` (or `Cmd+Shift+P` on Mac)
   - Select "Dev Containers: Reopen in Container"
   - Wait for the container to build and configure

3. **Start Development**:
   ```bash
   # The post-create script automatically runs:
   # - Restores .NET tools and packages
   # - Sets up CMake build system
   # - Installs git hooks
   # - Runs initial build and tests
   ```

### Using Docker Compose

For advanced scenarios with database services:

```bash
# Start all services
docker-compose -f .devcontainer/docker-compose.yml up -d

# Connect to the development container
docker-compose -f .devcontainer/docker-compose.yml exec app bash

# Stop all services
docker-compose -f .devcontainer/docker-compose.yml down
```

## Available Commands

Once in the container, you can use these CMake targets:

```bash
# Process grammar files (.y/.lex)
cmake --build build --target process

# Build the solution
cmake --build build --target build

# Run tests
cmake --build build --target test

# Format code
cmake --build build --target format

# Generate documentation
cmake --build build --target doc

# Package for NuGet
cmake --build build --target pack

# Install git hooks
cmake --build build --target install-hooks

# Clean build artifacts
cmake --build build --target clean-all
```

## Database Connections

When using Docker Compose, the following databases are available:

### SQL Server

```
Server: sqlserver,1433
Database: master
User: sa
Password: OpenLanguage123!
```

### MySQL

```
Server: mysql:3306
Database: openlanguage_test
User: testuser
Password: testpass
```

### PostgreSQL

```
Server: postgres:5432
Database: openlanguage_test
User: testuser
Password: OpenLanguage123!
```

### Redis

```
Server: redis:6379
```

## Environment Variables

The container sets these environment variables:

- `DOTNET_CLI_TELEMETRY_OPTOUT=1`: Disable .NET telemetry
- `DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1`: Skip .NET first-time setup
- `PATH`: Includes .NET tools and SQL Server tools

## VS Code Settings

The container configures VS Code with optimal settings for C# development:

- **IntelliSense**: Enhanced C# completion and hints
- **Formatting**: Automatic code formatting on save
- **Debugging**: Full debugging support with breakpoints
- **Testing**: Integrated test runner
- **Git**: Git integration with diff views

## Customization

### Adding Extensions

Edit `.devcontainer/devcontainer.json` and add to the `extensions` array:

```json
"extensions": [
    "your.extension.id"
]
```

### Modifying Settings

Update the `settings` section in `devcontainer.json`:

```json
"settings": {
    "your.setting": "value"
}
```

### Adding Services

Extend `docker-compose.yml` with additional services:

```yaml
services:
  your-service:
    image: your/image
    ports:
      - "port:port"
```

## Troubleshooting

### Container Won't Start

- Ensure Docker Desktop is running
- Check available disk space (containers need ~2GB)
- Verify no port conflicts (5000, 5001, 8080, 3000)

### Build Failures

- Run `dotnet restore` to refresh packages
- Clear build cache: `cmake --build build --target clean-all`
- Restart the container: "Dev Containers: Rebuild Container"

### Database Connection Issues

- Verify services are running: `docker-compose ps`
- Check health status: `docker-compose exec sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'OpenLanguage123!' -Q 'SELECT 1'`
- Restart database services: `docker-compose restart sqlserver mysql postgres`

### Performance Issues

- Allocate more memory to Docker Desktop (4GB+ recommended)
- Use volume mounts instead of bind mounts for better performance
- Close unnecessary applications to free system resources

## Support

For issues with the development container:

1. Check the [main README](../README.md) for general project setup
2. Review Docker Desktop logs
3. Create an issue with container logs and system information

---

_This development container provides a complete, isolated environment for OpenLanguage development with all necessary tools and dependencies pre-configured._
