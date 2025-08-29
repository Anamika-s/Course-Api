FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CourseApi.csproj", "."]
RUN dotnet restore "./CourseApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CourseApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseApi.dll"]