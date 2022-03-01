using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bpn_test_sso_netfwork_mvc_1.Controllers
{
    public class AccountController : Controller
    {
        public void Login()
        {
            // redirect page after authenticated
            string authenticatedUri = System.Configuration.ConfigurationManager.AppSettings["authenticatedUri"];

            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                // new AuthenticationProperties { RedirectUri = "/" },
                new AuthenticationProperties { RedirectUri = authenticatedUri },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);

            return RedirectToAction("Index", "Home");
        }
    }
}