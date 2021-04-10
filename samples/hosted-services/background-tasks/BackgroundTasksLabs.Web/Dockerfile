#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BackgroundTasksLabs.Web/BackgroundTasksLabs.Web.csproj", "BackgroundTasksLabs.Web/"]
RUN dotnet restore "BackgroundTasksLabs.Web/BackgroundTasksLabs.Web.csproj"
COPY . .
WORKDIR "/src/BackgroundTasksLabs.Web"
RUN dotnet build "BackgroundTasksLabs.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackgroundTasksLabs.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackgroundTasksLabs.Web.dll"]