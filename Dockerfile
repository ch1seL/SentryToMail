FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /app
COPY src .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime

WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "SentryToMail.API.dll"]