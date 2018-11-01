# VueJS_ClientServer

Vue.js client, WebApi server

SERVER:

hosted in IIS as http://vuejswebapiserver.localhost.com/api/employee
add to hosts file row: 127.0.0.1 vuejswebapiserver.localhost.com
give permissions for server project folder for
IIS AppPool\DefaultAppPool
IUSR

Web Api:

https://www.c-sharpcorner.com/UploadFile/8a67c0/getting-started-with-web-api-step-by-step-with-sample-applic/
Controller Method   Route URI
GetAllEmployees	/api/employee
GetEmployeeDetails	/api/employee/id
can be tested from index.html in Server project

Under Nuget Package Manager Console Run the following command to install CORS
Install-Package Microsoft.AspNet.WebApi.Cors
https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api


CLIENT:

created in Visual Studio Code
to run the project run command in Terminal:
npm run dev