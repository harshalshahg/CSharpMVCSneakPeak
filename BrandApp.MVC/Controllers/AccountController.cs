using AutoMapper;
using BrandApp.MVC.Models;
using BrandApp.Services.Business.Implementation;
using BrandApp.Services.Domain.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BrandApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountController));
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel webRegInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    log.Debug("Inside AccountController.Register.Submit");
                    User userObj = Mapper.Map<User>(webRegInfo);
                    bool registerServiceResult = UserService.RegisterUser(userObj);

                    if (registerServiceResult)
                    {
                        User userCredential = UserService.FindUserCredentialByUserName(webRegInfo.UserName);
                        Session["UserName"] = userCredential.UserName.Trim();
                        Session["UserID"] = userCredential.Id;
                        FormsAuthentication.SetAuthCookie(userCredential.UserName, false);
                        // login the user
                        return RedirectToAction("HomePage", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "UserName already Exists");
                        return View();
                    }
                }
                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                log.Error("AccountController.Register.Submit" + "CTRLR" + string.Format("An exception occurred registering the user. Message: {0}", e.GetBaseException().Message));
            }

            // If we got this far, something failed, redisplay form
            return View(webRegInfo);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel webCredentialLogin, string returnUrl)
        {
            try
            {
                log.Debug("Inside AccountController.Login");
                User webCredentialLoginUserObj = Mapper.Map<User>(webCredentialLogin);
                User validUser = UserService.AuthenticateWebCredential(webCredentialLoginUserObj);

                if (validUser != null)
                {
                    Session["UserName"] = validUser.UserName.Trim();
                    Session["UserID"] = validUser.Id;
                    FormsAuthentication.SetAuthCookie(validUser.UserName, false);
                    // successful login so redirect to the target url
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ViewBag.FailedToLogin = "Invalid username or password";
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception e)
            {
                log.Error("AccountController.Login" + "CTRLR" + "Authentication Error." + e);
            }

            // If we got this far, something failed, redisplay form
            return View(webCredentialLogin);
        }

        // POST or GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}