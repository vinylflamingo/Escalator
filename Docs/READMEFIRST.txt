:::: ESCALATOR ::::

Engineering Documentation v1 

Summary:
Escalator is a ticket based suport system. It is built with .Net Core 3.1. 
This initially was built to solve issues regarding database edits and call 
center escalations within a support organization. 


::: ARCHITECTURE :::

Escalator is made of two major projects. The API Project controls the back
end. It has the option of using either postgres server or SQL Server. It 
also controls the email service sending reports and notifications. 
The application also uses Jwt tokens for authentication. Currently their
are three authentication levels: user, manager, admin. 
    
    :: AUTHENTICATION LEVELS ::
    user: 
    Can add tickets. 
    Can edit their own tickets.
    Can view status of their tickets.

    manager: 
    * of user 
    Can edit all tickets
    Can be assigned tickets
    Can close tickets
    Can see open tickets

    admin:
    * of manager
    Can add agents, jurisdictions, ticketypes
    Can delete agents, jurisdictions, ticketypes, tickets
    Can reopen closed tickets

The other main project is the WebInterface. This host the UI and is 
completely decoupled from the API project. To call data, the project uses 
Processors. Otherwise the project is quite similair to most MVC projects.


::: PROJECTS :::

    :: API ::

    The API project is a .NET Core 3.1 API Project. It follows standard API 
    procedures for this kind of projects. It has 3 main services currently.
    One is API calls, and data processing. Two is email service which sends
    formatted emails. Three is the Jwt Authentication. It generates tokens
    to be used for the API to authorize calls to the API. 

        : CONNECTION : 
        You can pick between either postgres or SQL Server for the database 
        service. Entity framework can easily switch between both. 
    
        To select between the database types, you will modify the projects appsettings.json

        DatabaseType : "SQLSERVER" OR "POSTGRES"

        In the DatabaseType field, you can put either of those two string to 
        indicate which database you will be using. 

        ConnectionStrings : {}

        ConnectionStings will store different connections. You will select through 
        the different stored strings by changing the connectionString variable 
        in the Startup.cs file. Entity framework handles the database interactions
        so besides this, there should be no difference in code for specific databases.

        : EMAIL :
        The email service allows emails to be sent from Escaltor. The EmailService class 
        pulls the configuration from the appsettings. The app settings for smtp are quite standard.
        The FromAddress field does not need to be filled. 




