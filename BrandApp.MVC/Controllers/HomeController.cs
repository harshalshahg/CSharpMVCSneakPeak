using AutoMapper;
using BrandApp.MVC.Models;
using BrandApp.Services.Business.Implementation;
using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrandApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Brand> BrandList = BrandService.GetAllBrands();
            List<LandingPageViewModel> bvm = Mapper.Map<List<LandingPageViewModel>>(BrandList);
            return View(bvm);
        }

        public ActionResult HomePage()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                 int UserId = (int) Session["UserID"];
                List<int> preferedBrandList = BrandService.GetPreferredBrandIds(UserId);
                List<Brand> allBrandList = BrandService.GetAllBrands();
                List<HomePageViewModel> homePageViewModelList = Mapper.Map<List<HomePageViewModel>>(allBrandList);

                foreach (var i in homePageViewModelList)
                {
                    if (preferedBrandList.Contains(i.BrandId))
                    {
                        i.IsPreferred = true;
                    }
                }


                /*
                IEnumerable<HomePageViewModel> query = (from Brand in brandList
                                    join UserBrand in brandListPreferred
                                    on Brand.Id equals UserBrand.BrandID into bu
                                    from subBrand in bu.DefaultIfEmpty()
                                    select new HomePageViewModel { BrandName = Brand.Name,
                                        BrandImgUrl = Brand.BrandImgUrl,
                                        BrandDescription = Brand.Description,
                                        IsPreferred =(subBrand == null  ? false:true )}).OrderByDescending(a => a.IsPreferred);

                */


                ViewBag.SuccessMessage = TempData["AddRemoveSuccess"];
                return View(homePageViewModelList);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}