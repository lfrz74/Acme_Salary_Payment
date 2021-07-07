# Acme Salary Payment
## Initial Notes and prerequisites
1. Developed in .Net Core with C#
2. Visual Studio 2019 Community Edition (Free)
3. It's working with SQL Server Express 2016 (localDB), it can be downloaded and installed from: https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15 (This is a very lighweight version of Sql Server).

## Installation and Running the app
1. Run the command: git clone  https://github.com/lfrz74/Acme_Salary_Payment.git in the target folder
2. After install: SQL Server Express 2016, in file: appsettings.json , verify the conection to the database, just the name of the server, nothing else. 
"ConnectionStrings": {
    "AcmeDBConn": "Server=(localdb)\\mssqllocaldb;Database=AcmeDB;Trusted_Connection=True;"
 }
3. In VS2019, open package manager console and run this command: Update-Database , for creating the DB and inserting the data of the rates per hour in table DayRates, at once in the localDB

![pm](https://user-images.githubusercontent.com/30990338/124840755-4d783280-df51-11eb-8e5b-f8917a4be39a.PNG)

5. Run the app
6. In the following folder, there are several files for testing the app, you can select anyone of these files, but just file: AcmeUpload1.txt is formed well, the other 2 files produce errors

## Running the tests
1. For running the tests, it's just necessary to change the path, where the files of the folder: TestingFiles are, in your disk drive
2. For testing, i use an inmemory database
