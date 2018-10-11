FROM microsoft/dotnet:sdk AS publish

RUN mkdir /app
RUN mkdir /app/out

WORKDIR /app
COPY . ./

RUN dotnet publish               \
         --configuration release \
         --output /app/out       \
         /app/Onion.Web/Onion.Web.csproj

FROM microsoft/dotnet:aspnetcore-runtime AS deploy

RUN mkdir /app
WORKDIR /app

COPY --from=publish /app/out /app

CMD [ "dotnet", "/app/Onion.Web.dll" ]