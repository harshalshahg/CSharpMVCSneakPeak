using AutoMapper;
using BrandApp.MVC.Models;
using BrandApp.Services.Domain.Model;
using BrandApp.Services.Business.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace BrandApp.MVC.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowBrandDetails(int BrandId)
        {
            Brand brand = BrandService.GetBrandDetailsById(BrandId);
            BrandPageViewModel brandPageViewModel = Mapper.Map<BrandPageViewModel>(brand);
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                int UserId = (int)Session["UserID"];
                brandPageViewModel.isPreferredBrand = BrandService.isSelectedBrandPreferred(BrandId, Convert.ToInt32(UserId)); 
            }

            List<Promotion> promoList = PromotionService.GetPromotionsForBrandId(BrandId);
            List<PromotionPageViewModel> promoViewModelList = Mapper.Map<List<PromotionPageViewModel>>(promoList);
            brandPageViewModel.PromotionList = promoViewModelList;

            ViewBag.BrandUpdateFailed = TempData["AddRemoveFailed"];

            return View(brandPageViewModel);
        }


        public ActionResult AddBrand(int BrandId)
        {
            int UserId = (int)Session["UserID"];
            bool isAddSuccess = BrandService.AddBrandToPrefered(BrandId, Convert.ToInt32(UserId));
            if (isAddSuccess)
            {
                TempData["AddRemoveSuccess"] = "Brand Saved Sucessfully";
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                TempData["AddRemoveFailed"] = "Brand Not Saved Sucessfully, Please try after some time";
                return RedirectToAction("ShowBrandDetails", "Brand", new { BrandId = BrandId });
            }
        }


        public ActionResult RemoveBrand(int BrandId)
        {
            BrandService bs = new BrandService();
            int UserId = (int)Session["UserID"];
            bool isRemoveSucess = BrandService.RemoveBrandFromPrefered(BrandId, Convert.ToInt32(UserId));
            if (isRemoveSucess)
            {
                TempData["AddRemoveSuccess"] = "Brand Removed Sucessfully";
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                TempData["AddRemoveFailed"] = "Brand Not Removed Sucessfully, Please try after some time";
                return RedirectToAction("ShowBrandDetails", "Brand", new { BrandId = BrandId });
            }
        }
    }
}