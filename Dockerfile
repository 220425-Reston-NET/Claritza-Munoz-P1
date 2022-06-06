#another stage that is about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app

#cmd docker instructions tells the docker engine how/where to run this application
entrypoint ["dotnet", "StoreAppAPI.dll"]

#expose to part 5000
expose 5000

#we need to change our ASP.NET application to also start listening to 5000 port
env ASPNETCORE_URLS=https://+:5000