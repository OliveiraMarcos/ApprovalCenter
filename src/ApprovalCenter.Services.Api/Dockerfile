#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
#COPY . .
COPY ["src/ApprovalCenter.Services.Api/ApprovalCenter.Services.Api.csproj", "src/ApprovalCenter.Services.Api/"]
COPY ["src/ApprovalCenter.Infra.CrossCutting.IoC/ApprovalCenter.Infra.CrossCutting.IoC.csproj", "src/ApprovalCenter.Infra.CrossCutting.IoC/"]
COPY ["src/ApprovalCenter.Application/ApprovalCenter.Application.csproj", "src/ApprovalCenter.Application/"]
COPY ["src/ApprovalCenter.Domain/ApprovalCenter.Domain.csproj", "src/ApprovalCenter.Domain/"]
COPY ["src/ApprovalCenter.Domain.Core/ApprovalCenter.Domain.Core.csproj", "src/ApprovalCenter.Domain.Core/"]
COPY ["src/ApprovalCenter.Infra.Data/ApprovalCenter.Infra.Data.csproj", "src/ApprovalCenter.Infra.Data/"]
COPY ["src/ApprovalCenter.Infra.CrossCutting.Bus/ApprovalCenter.Infra.CrossCutting.Bus.csproj", "src/ApprovalCenter.Infra.CrossCutting.Bus/"]
COPY ["src/ApprovalCenter.Infra.CrossCutting.Identity/ApprovalCenter.Infra.CrossCutting.Identity.csproj", "src/ApprovalCenter.Infra.CrossCutting.Identity/"]
RUN dotnet restore "src/ApprovalCenter.Services.Api/ApprovalCenter.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/ApprovalCenter.Services.Api"
RUN dotnet build "ApprovalCenter.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApprovalCenter.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY cert-aspnetcore.pfx .

ENV JWT_SECONDS=120
ENTRYPOINT ["dotnet", "ApprovalCenter.Services.Api.dll"]