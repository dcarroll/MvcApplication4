using MvcApplication3.Services.Salesforce;
using MvcApplication4.Models.Salesforce;
using MvcApplication4.Services.Salesforce;
using Salesforce.Common.Models;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class LeadController : Controller
    {
        //
        // GET: /Lead/

        public async Task<ActionResult> LeadList()
        {
            // Ensure the user is authenticated
            if (!SalesforceService.IsUserLoggedIn())
            {
                // Should include a state argument to the URI so that when the dance is done, we can redirect to the page that we were requesting
                string myUri = SalesforceOAuthRedirectHandler.AuthorizationUri.ToString() + "&state=" + this.Url.RequestContext.HttpContext.Request.RawUrl;
                return this.Redirect(myUri);
            }
            // Initialize the Force client
            SalesforceService service = new SalesforceService();
            ForceClient client = service.GetForceClient();

            // Query just the properties we need to display the selection with SOQL 
            // Querying all properties would waste bandwidth and performance
            QueryResult<Lead> leads =
                await client.QueryAsync<Lead>("SELECT Id, FirstName, LastName,  City, State, Country From Lead");

            return View(leads.records);
        }
        public async Task<ActionResult> LeadDetail(string id)
        {
            // Ensure the user is authenticated
            if (!SalesforceService.IsUserLoggedIn())
            {
                // Should include a state argument to the URI so that when the dance is done, we can redirect to the page that we were requesting
                string myUri = SalesforceOAuthRedirectHandler.AuthorizationUri.ToString() + "&state=" + this.Url.RequestContext.HttpContext.Request.RawUrl;
                return this.Redirect(myUri);
            }

            // Initalize the Force client
            SalesforceService service = new SalesforceService();
            ForceClient client = service.GetForceClient();

            Lead lead = await client.QueryByIdAsync<Lead>("Lead", id);

            return View(lead);
        }

        public async Task<ActionResult> LeadEdit(string id)
        {
            // Ensure the user is authenticated
            if (!SalesforceService.IsUserLoggedIn())
            {
                // Should include a state argument to the URI so that when the dance is done, we can redirect to the page that we were requesting
                string myUri = SalesforceOAuthRedirectHandler.AuthorizationUri.ToString() + "&state=" + this.Url.RequestContext.HttpContext.Request.RawUrl;
                return this.Redirect(myUri);
            }

            // Initalize the Force client
            SalesforceService service = new SalesforceService();
            ForceClient client = service.GetForceClient();

            Lead lead = await client.QueryByIdAsync<Lead>("Lead", id);

            return View(lead);

        }

        // POST: /Lead/LeadEdit/003i000000tm2KSAAY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LeadEdit(Lead lead)
        {
            // TODO: Resolve Edit failures with ID
            // Ensure the user is authenticated
            if (!SalesforceService.IsUserLoggedIn())
            {
                // Should include a state argument to the URI so that when the dance is done, we can redirect to the page that we were requesting
                string myUri = SalesforceOAuthRedirectHandler.AuthorizationUri.ToString() + "&state=" + this.Url.RequestContext.HttpContext.Request.RawUrl;
                return this.Redirect(myUri);
            }
            // Initialize the Force client
            SalesforceService service = new SalesforceService();
            ForceClient client = service.GetForceClient();

            var success = await client.UpdateAsync("Lead", lead.Id, lead);
            if (success.errors == null)
            {
                return RedirectToAction("LeadList");
            }
            else
            {
                return View(lead);
            }
        }

        public async Task<ActionResult> LeadDelete(string id)
        {
            // TODO: Resolve Edit failures with ID
            // Ensure the user is authenticated
            if (!SalesforceService.IsUserLoggedIn())
            {
                // Should include a state argument to the URI so that when the dance is done, we can redirect to the page that we were requesting
                string myUri = SalesforceOAuthRedirectHandler.AuthorizationUri.ToString() + "&state=" + this.Url.RequestContext.HttpContext.Request.RawUrl;
                return this.Redirect(myUri);
            }
            // Initialize the Force client
            SalesforceService service = new SalesforceService();
            ForceClient client = service.GetForceClient();

            var success = await client.DeleteAsync("Lead", id);
                return RedirectToAction("LeadList");
        }
    }
}
