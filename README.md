# Water
Super simple app to show how many glasses of water I had on a given date

## Technology
* The API is built on .NET Core
* The data is read from a DynamoDB (which should already exists)
* The frontend is built in React with hooks


## Prequisites
* You need to have a AWS profile called "water" in your system
* You need to add an IAM user with permissions to read from DynamoDB
* This asumes you will use the region us-west-2. You can change the region in the config file of the API (appsettings.Development.json)
* You need to create a dynamoDB table called `rosario_water` with the following structure:

`date (string)`

`glasses (int)`

## How to run

### API
Open the SLN, set the Startup to the Water.API. It will run in IIS Express on the port 44398

### Web
```
npm install

npm run
```
