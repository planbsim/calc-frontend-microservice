FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./WebCalculator/*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
ENV SOLUTIONDIR=/app
RUN dotnet publish ./WebCalculator/WebCalculator.csproj -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/WebCalculator/out .
ENTRYPOINT ["dotnet", "WebCalculator.dll"]