FROM mcr.microsoft.com/dotnet/sdk:8.0 as builder
WORKDIR /app
COPY . .
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=builder /app/out .
CMD ["dotnet", "ping-api.dll"]
