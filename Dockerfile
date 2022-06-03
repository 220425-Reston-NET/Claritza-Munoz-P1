# docerfilee is like an instruction manual for the computer to follow to let it create an Image
# from instruction will tell docker image that this image will depend on this SDK to run
#  dockerhub is equivalent to github and we  are just pulling an image version of our SDK to put in this image 
from mcr.microsoft.com/dotnet/sdk:6.0 as build


#workdir docker instruction let use create what our working directory will be for this image
workdir /app

#copy docker instruction will et us copy files from this computer to put inside of the docker image
copy *.sln ./
copy StoreAppAPI/*.csproj StoreAppAPI/
copy StoreAppBL/*.csproj StoreAppBL/
copy StoreAppDL/*.csproj StoreAppDL/
copy StoreAppModel/*.csproj StoreAppModel/
copy StoreAppTest/*.csproj StoreAppTest/

# now we will copy the rest after setting up our project structure
copy . ./

# restoring our bin and object files
# run docker instruction will run a CLI command in the image
run dotnet build

#it will create a published folder that will hold all the info to be able to run your app
run dotnet publish -c Release -o publish

#multi-stage build in docker
#allows us to have multiple ways to create our application
# first stage was all about building our application hence why we neeed an SDK
#ultimately it was just to run dotnet build and  dotnet publish

#another stage that is about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
copy --from=build /app/publish ./

#cmd docker instructions tells the docker engine how/where to run this application
cmd ["dotnet", "StoreAppAPI.dll"]

#expose to part 80
expose 80