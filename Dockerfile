#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
EXPOSE 80
EXPOSE 443
# FROM emscripten/emsdk:3.1.26
# soft link
RUN ln -s /lib/x86_64-linux-gnu/libdl-2.24.so /lib/x86_64-linux-gnu/libdl.so

# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
   		libgdiplus \
#         libc6-dev \
#         libgdiplus \
#         libx11-dev \
     && rm -rf /var/lib/apt/lists/*

# Install Python3
RUN apt-get update
RUN apt-get install -y python3

WORKDIR /src
COPY . .
RUN dotnet restore

COPY . .
FROM build AS publish
RUN dotnet publish "/src/AY.Textiles.API" -c Release -o /app/publish --no-restore

#final build
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AY.Textiles.API.dll