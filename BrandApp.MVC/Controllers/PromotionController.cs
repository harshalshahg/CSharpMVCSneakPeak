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
    public class PromotionController : Controller
    {
        // GET: Promotion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowPromotionDetails(int promotionId)
        {
            Promotion promoList = PromotionService.GetPromotionsByPromotionId(promotionId);
            PromotionPageViewModel promoViewModel = Mapper.Map<PromotionPageViewModel>(promoList);
            return View(promoViewModel);
        }
    }
}