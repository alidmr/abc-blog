
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AbcBlog.Api/AbcBlog.Api.csproj", "src/AbcBlog.Api/"]
COPY ["src/AbcBlog.Shared/AbcBlog.Shared.csproj", "src/AbcBlog.Shared/"]
COPY ["src/AbcBlog.Infrastructure/AbcBlog.Infrastructure.csproj", "src/AbcBlog.Infrastructure/"]
COPY ["src/AbcBlog.Domain/AbcBlog.Domain.csproj", "src/AbcBlog.Domain/"]
RUN dotnet restore "src/AbcBlog.Api/AbcBlog.Api.csproj"
COPY . .
WORKDIR "/src/src/AbcBlog.Api"
RUN dotnet build "AbcBlog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AbcBlog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AbcBlog.Api.dll"]