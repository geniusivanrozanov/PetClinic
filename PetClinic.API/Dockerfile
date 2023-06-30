FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PetClinic.API/PetClinic.API.csproj", "PetClinic.API/"]
COPY ["PetClinic.DAL/PetClinic.DAL.csproj", "PetClinic.DAL/"]
COPY ["PetClinic.BLL/PetClinic.BLL.csproj", "PetClinic.BLL/"]
RUN dotnet restore "PetClinic.API/PetClinic.API.csproj"
COPY . .
WORKDIR "/src/PetClinic.API"
RUN dotnet build "PetClinic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetClinic.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetClinic.API.dll"]
