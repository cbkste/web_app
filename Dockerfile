FROM microsoft/dotnet:1.0.0-rc2-core
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "web_app.dll"]
COPY . /app
