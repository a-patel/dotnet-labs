#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MiniProfilerExamples.Api/MiniProfilerExamples.Api.csproj", "MiniProfilerExamples.Api/"]
RUN dotnet restore "MiniProfilerExamples.Api/MiniProfilerExamples.Api.csproj"
COPY . .
WORKDIR "/src/MiniProfilerExamples.Api"
RUN dotnet build "MiniProfilerExamples.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiniProfilerExamples.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniProfilerExamples.Api.dll"]