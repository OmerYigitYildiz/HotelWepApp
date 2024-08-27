# Uygulaman n in as  i in resmi .NET 5 SDK imaj n  kullan yoruz
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Container i indeki  al  ma dizinini ayarl yoruz
WORKDIR /app

# Ba  ml l klar  kopyalay p y kl yoruz
COPY ["HotelDomain/HotelDomain.csproj", "HotelDomain/"]
COPY ["HotelInfrastructure/HotelInfrastructure.csproj", "HotelInfrastructure/"]
COPY ["HotelApplication/HotelApplication.csproj", "HotelApplication/"]
COPY ["HotelApi/HotelApi.csproj", "HotelApi/"]
RUN dotnet restore "HotelApi/HotelApi.csproj"

# Projenin geri kalan n  kopyalay p in a ediyoruz
COPY . .
RUN dotnet publish "HotelApi/HotelApi.csproj" -c Release -o out

#  al  ma zaman  imaj  olu turuluyor
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# Uygulaman n  al  aca   portu a  yoruz
EXPOSE 80
EXPOSE 443

# Container i in giri  noktas  ayarl yoruz
ENTRYPOINT ["dotnet", "HotelApi.dll"]