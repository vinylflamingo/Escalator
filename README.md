:::: ESCALATOR ::::

Documentation v0.4

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

To select between the database types, you will modify the projects 
appsettings.json

DatabaseType : "SQLSERVER" OR "POSTGRES"

In the DatabaseType field, you can put either of those two string to 
indicate which database you will be using. 

ConnectionStrings : {}

ConnectionStings will store different connections. You will select 
through the different stored strings by changing the connectionString 
variable in the Startup.cs file. Entity framework handles the database 
interactions so besides this, there should be no difference in code 
for specific databases.

: CONTACT :
The contact system generates notifications and reports for the users. 
ContactService class lays the ground work for all the contact records 
to use. It can create new records, send emails, save records to database, and also check for Opt In options. Each contact method inherits from the IContact interface. 

: JWT AUTH :
The authentication system makes use of Jwt generated tokens. The 
key for the Jwt token system is located in the Startup.CS file 
directly above authentication. The Jwt authentication is also a
singleton registered as a service. The majority of the code for 
the Jwt authentication is in JwtAuthenticationManager.cs. This class 
is called upon a login request. It will check the database to see 
if the credentials are correct. If so it will also find the agents 
authentication level and encrypt that into the token. On the UI side, 
the token is currently store in the session information. This may not 
be permanent, and is still in research. Tokens last for 4 horus before 
expiring.


:: COMMON :: 

This is a simple class library sharing the standard types for the project. 
All other main projects reference this project, insuring type integrity 
between all. It only consist of one folder: Models. In the future, 
it may be possible that I might put some other functions in there that both 
projects may use. 

:: DOCS ::

Where your at now! Just text describing the application.

:: HTML_TEMPLATE_FILES ::

The UI uses a template. This is the original template files to reference.
They are not used in any of the projects, and are not included in a any build.
Purely for reference only. 

:: WebInterface :: 

This is the main UI project. It uses ASP.NET CORE 3.1 MVC. It follow the standard 
path for a MVC project. The only main difference is there is no DbContext. Instead 
data is sent and retrieved by Processors that make HTTP request. This is done so 
to completely decouple the UI from the Backend. And in the future, make it easier to
move to another UI platform, say for example if I wanted to use a javascript framework
like react or vue. The app settings really only contains one setting. The application
needs to know where the API is located, so it can be called by the ApiHelper class.
The processors handle all the data calls. The Login processor, is unique in that it
strictly only handles the login procedures and storing of session informaiton.
The sessions stores two fields 1. The Jwt Token. 2. The username who is using said token.
The plan is control some auth on the UI side by using the role stored in the token, or 
possibly by adding a third field in the session titled role. 





USELFUL CLI COMMANDS:
dotnet build - build project
dotnet ef migrations add *nameHere* - add migration for next db update
dotnet ef database update - update database according to migrations
dotnet dev-certs https --clean  - removes certs 
dotnet dev-certs https --trust  - creates new local cert
dotnet publish -c Release -o ./publish/0.2  - publish new version. the 0.2 is a version number. 
git rm --cached WebInterface/appsettings.json - remove from git tracking









