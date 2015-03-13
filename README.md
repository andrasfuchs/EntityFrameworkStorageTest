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
This is fairly easy to configure and well-supported.

You need the following NuGet packages to be installed:
* [EntityFramework](http://www.nuget.org/packages/EntityFramework/)
* [EntityFramework.SqlServerCompact](http://www.nuget.org/packages/EntityFramework.SqlServerCompact/)
* [Microsoft.SqlServer.Compact](http://www.nuget.org/packages/Microsoft.SqlServer.Compact/)

You need to have these lines in the App.config of both the DataModel and Main projects:

    <entityFramework>
      <providers>
        <provider invariantName="System.Data.SqlServerCe.4.0" type="System.Data.Entity.SqlServerCompact.SqlCeProviderServices, EntityFramework.SqlServerCompact" />
      </providers>
    </entityFramework>
     <system.data>
      <DbProviderFactories>
        <remove invariant="System.Data.SqlServerCe.4.0" />
        <add name="Microsoft SQL Server Compact Data Provider 4.0" invariant="System.Data.SqlServerCe.4.0" description=".NET Framework Data Provider for Microsoft SQL Server Compact" type="System.Data.SqlServerCe.SqlCeProviderFactory, System.Data.SqlServerCe, Version=4.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" />
      </DbProviderFactories>
     </system.data>

And you need to customize the following connection string to your needs in the App.config of the Main project:

    <add name="StorageTest.DataModel.DvdContext" providerName="System.Data.SqlServerCe.4.0" connectionString="Data Source=|DataDirectory|DVDDatabase.sdf" />

SQLite
------
This is more difficult to configure and migrations are not supported. SQLite outperforms SQL Compact Edition though.

You need the following NuGet packages to be installed:
* [EntityFramework](http://www.nuget.org/packages/EntityFramework/)
* [System.Data.SQLite.Core](http://www.nuget.org/packages/System.Data.SQLite.Core/)
* [System.Data.SQLite.EF6](http://www.nuget.org/packages/System.Data.SQLite.EF6/)

You need to have these lines in the App.config of both the DataModel and Main projects:

    <entityFramework>
      <providers>
        <provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
      </providers>
    </entityFramework>
     <system.data>
      <DbProviderFactories>
        <remove invariant="System.Data.SQLite.EF6" />
        <add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".NET Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6" />
      </DbProviderFactories>
     </system.data>

And you need to customize the following connection string to your needs in the App.config of the Main project:

    <add name="StorageTest.DataModel.DvdContext" providerName="System.Data.SQLite.EF6" connectionString="Data Source=|DataDirectory|DVDDatabase.sqlite" />

Migrations
==========
Migrations are stored in the DataModel project. All migrations are applied automatically by the "MigrateDatabaseToLatestVersion" context initializer.

When you change the data model, you should run the "Add-Migration <migration name>" command in the Package Manager Console (in Visual Studio). Make sure you selected the DataModel project in the head of the Package Manager Console. It a good practice to give the migration a name which describes the changes you made (e.g. AddedNotesToFilmObject). This will generate the necessary migration files. They will run next time when you access the database.

It is also good to know, that the Seed method in the Configuration.cs run every time you access the DB for the first time whithin your application.

