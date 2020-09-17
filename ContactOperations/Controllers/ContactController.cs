using ContactOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace ContactOperations.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        private ILog _ILog;
        public ContactController()
        {
            _ILog = Log.GetInstance;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }


        public ActionResult Index()
        {
            IEnumerable<ContactModel> contactList;
            
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ContactDetails").Result;
            contactList = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;
            
            return View(contactList);
        }

        public ActionResult AddOrEdit(int Id=0)
        {
            if (Id == 0)
                return View(new ContactModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ContactDetails/" + Id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ContactModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(ContactModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("ContactDetails", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("ContactDetails/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");          
            
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("ContactDetails/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}