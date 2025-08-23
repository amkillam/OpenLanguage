# Use the official .NET 9.0 development container as base
FROM mcr.microsoft.com/devcontainers/dotnet:1-9.0

# Install additional tools and dependencies
RUN apt-get update && apt-get install -y \ 
  # Build tools
  build-essential \
  gcc \
  g++ \
  make \
  cmake \
  # Development tools
  git \
  curl \
  wget \
  unzip \
  tree \
  jq \
  vim \
  nano \
  # ODBC drivers and tools
  unixodbc \
  unixodbc-dev \
  # SQL Server ODBC driver\
  && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
  && curl https://packages.microsoft.com/config/ubuntu/22.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \
  && apt-get update \
  && ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools18 \
  # MySQL ODBC driver
  && apt-get install -y libmyodbc \
  # PostgreSQL ODBC driver\
  && apt-get install -y odbc-postgresql \
  # Clean up\
  && apt-get autoremove -y \
  && apt-get clean \
  && rm -rf /var/lib/apt/lists/*

# Add SQL Server tools to PATH
ENV PATH="$PATH:/opt/mssql-tools18/bin"

# Install Node.js LTS (for any frontend tooling)
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash - \
  && apt-get install -y nodejs

# Install GitHub CLI
RUN curl -fsSL https://cli.github.com/packages/githubcli-archive-keyring.gpg | dd of=/usr/share/keyrings/githubcli-archive-keyring.gpg \
  && chmod go+r /usr/share/keyrings/githubcli-archive-keyring.gpg \
  && echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/githubcli-archive-keyring.gpg] https://cli.github.com/packages stable main" | tee /etc/apt/sources.list.d/github-cli.list > /dev/null \
  && apt-get update \
  && apt-get install gh -y

# Set up workspace
WORKDIR /workspaces/OpenLanguage

# Copy and set up post-create script
COPY post-create.sh /tmp/post-create.sh
RUN chmod +x /tmp/post-create.sh

# Set default user
USER vscode

# Install global .NET tools
RUN dotnet tool install --global docfx \
  && dotnet tool install --global csharpier

# Add .NET tools to PATH
ENV PATH="$PATH:/home/vscode/.dotnet/tools"
