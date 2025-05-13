FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["QAInsight.Web/QAInsight.Web.csproj", "QAInsight.Web/"]
COPY ["QAInsight.Application/QAInsight.Application.csproj", "QAInsight.Application/"]
COPY ["QAInsight.Domain/QAInsight.Domain.csproj", "QAInsight.Domain/"]
COPY ["QAInsight.Infrastructure/QAInsight.Infrastructure.csproj", "QAInsight.Infrastructure/"]
RUN dotnet restore "QAInsight.Web/QAInsight.Web.csproj"
COPY . .
WORKDIR "/src/QAInsight.Web"
RUN dotnet build "QAInsight.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QAInsight.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QAInsight.Web.dll"] 