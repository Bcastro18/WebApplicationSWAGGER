using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplicationSWAGGER.Controllers
{
    public class ErrorHandlingWebAPIController : Controller
    {

        [System.Web.Mvc.Route("CheckId/{id}")]
        [System.Web.Mvc.HttpGet]
        public IHttpActionResult CheckId(int id)
        {
            if (id < 10) // No error hanbdling at all:
            {
                int a = 1;
                int b = 0;
                int c = 0;
                c = a / b; //it would cause exception.
            }
            else if (id < 20) // Error handling by HttpResponseException with HttpStatusCode
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if (id < 30) // Error handling by HttpResponseException with HttpResponseMessage
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("No Employee found with ID = {0}", 10)),
                    ReasonPhrase = "Employee Not Found"
                };

                throw new HttpResponseException(response);
            }

            return Ok(id);

        }

        private IHttpActionResult Ok(int id)
        {
            throw new NotImplementedException();
        }

        // GET: ErrorHandlingWebAPI
        public ActionResult Index()
        {
            return View();
        }
    }
}