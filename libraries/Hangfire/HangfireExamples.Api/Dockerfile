#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HangfireExamples.Api/HangfireExamples.Api.csproj", "HangfireExamples.Api/"]
RUN dotnet restore "HangfireExamples.Api/HangfireExamples.Api.csproj"
COPY . .
WORKDIR "/src/HangfireExamples.Api"
RUN dotnet build "HangfireExamples.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HangfireExamples.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HangfireExamples.Api.dll"]