# .NET Core Build
FROM microsoft/dotnet:latest AS dotnetcore-build
WORKDIR /source

# Copy Projects Files
COPY source/Domain/MoviesWorldCup.Domain.csproj ./Domain/
COPY source/IoC/MoviesWorldCup.IoC.csproj ./IoC/
COPY source/Model/MoviesWorldCup.Model.csproj ./Model/
COPY source/Web/MoviesWorldCup.Web.csproj ./Web/

# ASP.NET Core Restore
RUN dotnet restore ./Web/MoviesWorldCup.Web.csproj

# Copy All Files
COPY source .

# ASP.NET Core Build
RUN dotnet build ./Web/MoviesWorldCup.Web.csproj -c Release -o /app

# ASP.NET Core Publish
FROM dotnetcore-build AS dotnetcore-publish
RUN dotnet publish ./Web/MoviesWorldCup.Web.csproj -c Release -o /app

# Angular
FROM node:alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/Web/Frontend/package.json .
RUN npm run restore
COPY source/Web/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM microsoft/dotnet:2.1.5-aspnetcore-runtime AS aspnetcore-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM aspnetcore-runtime AS aspnetcore-angular
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=dotnetcore-publish /app .
COPY --from=angular-build /frontend/dist ./Frontend/dist
ENTRYPOINT ["dotnet", "MoviesWorldCup.Web.dll"]
