# CustomerAppBackend

## How to install the database from EntityFramework Core Code First approach and run the project .
-> First open the visual code then from solution explorer click appsettings.json change the server ="your database server name".
-> Check if the Migration folder is already available, if it is then delete it then process with the below given instruction.
-> Open NuGet Package Manager Console from Tools -> NuGet Package Manager -> Package Manager Console and enter the following command: PM> add-migration InitialCreateDb and PM> update-database.
-> Then click CustomerPurchaseApp to run the project.
