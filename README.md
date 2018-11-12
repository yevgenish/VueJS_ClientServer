# VueJS_ClientServer

Vue.js client. WebApi server<br /><br />

<b>SERVER:</b><br />
hosted in IIS as http://vuejswebapiserver.localhost.com/api/v1/employee
<br />
add to hosts file row: 127.0.0.1 vuejswebapiserver.localhost.com<br />
give permissions for server project folder for<br />
IIS AppPool\DefaultAppPool<br />
IUSR<br />

Web Api:<br />
Controller Method   and Route URI<br />
GetEmployees (all)	/api/employee<br />
GetEmployeeDetails	/api/employee/id<br />
can be tested from index.html in Server project<br />

Under Nuget Package Manager Console Run the following command to install CORS<br />
Install-Package Microsoft.AspNet.WebApi.Cors<br />
https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
<br /><br />

To install <b>Swagger</b>, to explore WebApi services, run the following command:<br />
Install-Package Swashbuckle<br />
Swagger url:<br />
http://vuejswebapiserver.localhost.com/swagger
<br /><br />

<b>CLIENT:</b><br />
created in Visual Studio Code with Vue.js<br />
to run the project run command in Terminal:<br />
npm run dev<br />


