# Uygulamanýn inþasý için resmi .NET 5 SDK imajýný kullanýyoruz
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Container içindeki çalýþma dizinini ayarlýyoruz
WORKDIR /app

# Baðýmlýlýklarý kopyalayýp yüklüyoruz
COPY ["HotelDomain/HotelDomain.csproj", "HotelDomain/"]
COPY ["HotelInfrastructure/HotelInfrastructure.csproj", "HotelInfrastructure/"]
COPY ["HotelApplication/HotelApplication.csproj", "HotelApplication/"]
COPY ["HotelApi/HotelApi.csproj", "HotelApi/"]
RUN dotnet restore "HotelApi/HotelApi.csproj"

# Projenin geri kalanýný kopyalayýp inþa ediyoruz
COPY . .
RUN dotnet publish "HotelApi/HotelApi.csproj" -c Release -o out

# Çalýþma zamaný imajý oluþturuluyor
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

# Uygulamanýn çalýþacaðý portu açýyoruz
EXPOSE 80
EXPOSE 443

# Container için giriþ noktasý ayarlýyoruz
ENTRYPOINT ["dotnet", "HotelApi.dll"]
