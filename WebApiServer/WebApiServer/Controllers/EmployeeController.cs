using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiServer.Models;

namespace WebApiServer.Controllers
{
    //hosted in IIS as http://vuejswebapiserver.localhost.com/api/employee
    //add to hosts file row: 127.0.0.1 vuejswebapiserver.localhost.com
    //give permissions for server project folder for
    //IIS AppPool\DefaultAppPool
    //IUSR

    //https://www.c-sharpcorner.com/UploadFile/8a67c0/getting-started-with-web-api-step-by-step-with-sample-applic/
    //Controller Method   Route URI
    //GetAllEmployees	/api/employee
    //GetEmployeeDetails	/api/employee/id

    //Under Nuget Package Manager Console install the following command to install CORS
    //Install-Package Microsoft.AspNet.WebApi.Cors
    //https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api

    //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        static IList<Employee> employees = new List<Employee>()
        {
            new Employee()
                {
                    EmployeeId = 1, EmployeeName = "John Doe", Address = "New York", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 2, EmployeeName = "Jane Doe", Address = "Los Angeles", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Tauno Tavallinen", Address = "Helsinki", Department = "Legal"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "Jan Jansen", Address = "Amsterdam", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Ze Povinho", Address = "Lisbon", Department = "Marketing"
                },
        };

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return employees;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        [HttpGet]
        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                //Return a single employee detail  
                var employee = employees.FirstOrDefault(e => e.EmployeeId == id);
                if (employee == null)
                {
                    //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
                return employee;
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }

        [HttpPut]
        public HttpResponseMessage PutEmployee([FromBody]Employee employee)
        {
            try
            {
                //throw new Exception("just exception");

                var max = employees.Any() == false ? 0 : employees.Max(el => el.EmployeeId);

                employee.EmployeeId = max + 1;
                employees.Add(employee);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                //log exception
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }

        [HttpPost]
        public HttpResponseMessage PostEmployee([FromBody]Employee employee)
        {
            try
            {
                if (employee == null || !(employee.EmployeeId > 0))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                var currentEmployee = employees.FirstOrDefault(em => em.EmployeeId == employee.EmployeeId);

                if (currentEmployee != null)
                {
                    currentEmployee.Address = employee.Address;
                    currentEmployee.Department = employee.Department;
                    currentEmployee.EmployeeName = employee.EmployeeName;

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                //log exception
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                if (!(id > 0))
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                int amountOfRemoved = ((List<Employee>)employees).RemoveAll(el => el.EmployeeId == id);
                if (amountOfRemoved == 1)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                //log exception
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
