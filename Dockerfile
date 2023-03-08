# Create build machine
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
#TODO install dotnet, node, etc

# Copy source files
WORKDIR /source
COPY . ./

# Build front-end (which gets written to /source/backend/Api/wwwroot)
RUN cd /source/frontend
RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash
ENV NVM . /root/.nvm/nvm.sh
ENV NODE_VERSION=19.7.0
RUN . $NVM && nvm install ${NODE_VERSION}
RUN . $NVM && nvm use v${NODE_VERSION}
RUN . $NVM && nvm alias default v${NODE_VERSION}
ENV PATH="/root/.nvm/versions/node/v${NODE_VERSION}/bin/:${PATH}"


# Build back-end
RUN cd /source/backend/Api
RUN dotnet restore
RUN dotnet publish -c Release -o out


ENV NVM_DIR=/root/.nvm
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
RUN node --version
RUN npm --version


# RUN ls -la
# RUN cd source/backend/Api
# RUN dotnet restore

# Create runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

# # Copy the app from the builder stage
# WORKDIR /app
# COPY --from=builder /source/backend/Api/out .
# # Expose port 80 (remap it using -p or via docker-compose.yml)
# EXPOSE 80
# # Start the app
# ENTRYPOINT dotnet partsbin.dll




