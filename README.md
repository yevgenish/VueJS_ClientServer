# VueJS_ClientServer

Vue.js client, WebApi server<br /><br />

<b>SERVER:</b><br />
hosted in IIS as http://vuejswebapiserver.localhost.com/api/employee
<br />
add to hosts file row: 127.0.0.1 vuejswebapiserver.localhost.com<br />
give permissions for server project folder for<br />
IIS AppPool\DefaultAppPool<br />
IUSR<br />

Web Api:<br />
https://www.c-sharpcorner.com/UploadFile/8a67c0/getting-started-with-web-api-step-by-step-with-sample-applic/
<br />
Controller Method   Route URI<br />
GetAllEmployees	/api/employee<br />
GetEmployeeDetails	/api/employee/id<br />
can be tested from index.html in Server project<br />

Under Nuget Package Manager Console Run the following command to install CORS<br />
Install-Package Microsoft.AspNet.WebApi.Cors<br />
https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
<br /><br />

<b>CLIENT:</b><br />
created in Visual Studio Code<br />
to run the project run command in Terminal:<br />
npm run dev<br />