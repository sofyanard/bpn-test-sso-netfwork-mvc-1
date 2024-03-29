﻿using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace bpn_test_sso_netfwork_mvc_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            /*
            ViewBag.Message = "Your application description page.";

            return View();
            */

            ViewBag.Message = "Your application description page.";

            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;

            //You get the user's first and last name below:
            ViewBag.Name = userClaims?.FindFirst("name")?.Value;
            ViewBag.LoginName = userClaims?.FindFirst("preferred_username")?.Value;
            ViewBag.Email = userClaims?.FindFirst(p => p.Type.Contains("emailaddress"))?.Value;

            var userPrinciple = User as ClaimsPrincipal;

            return View(userPrinciple);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}