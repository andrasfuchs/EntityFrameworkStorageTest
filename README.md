# Entity Framework 6 - Storage Test Console Application

Entity Framework 6 sample application with configurations for various storages.

There are two projects in the solution DataModel (which contains the data model and the EF migrations files) and Main console application.


When you run the console app, it creates the database if it doesn't exists, applies the migration steps and seeds the tables with basic data.
 This code run in the DataModel using the standard methods of EF.

After this initialization process the program code in the console application tries to find some data, insert new entries into a few tables and update the DB.


This whole process is totally database-independent, so it is easy to switch between datastores.

Configuration
=============

Microsoft SQL Express 2014
--------------------------
This is the easiest to use.

You need the following NuGet packages to be installed:
* [EntityFramework](http://www.nuget.org/packages/EntityFramework/)

You need to have these lines in the App.config of both the DataModel and Main projects:

    <entityFramework>
      <providers>
        <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
      </providers>
    </entityFramework>

And you need to customize the following connection string to your needs in the App.config of the Main project:

    <add name="StorageTest.DataModel.DvdContext" providerName="System.Data.SqlClient" connectionString="Initial Catalog=DVDDatabase;Server=.\SQLEXPRESS;Trusted_Connection=true;" />


Microsoft SQL Compact Edition 4.0
---------------------------------

SQLite
------


Migrations
==========
