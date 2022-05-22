#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LMS_Publisher_Api/LMS_Publisher_Api.csproj", "LMS_Publisher_Api/"]
RUN dotnet restore "LMS_Publisher_Api/LMS_Publisher_Api.csproj"
COPY . .
WORKDIR "/src/LMS_Publisher_Api"
RUN dotnet build "LMS_Publisher_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LMS_Publisher_Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS_Publisher_Api.dll"]