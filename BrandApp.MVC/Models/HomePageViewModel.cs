﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApp.MVC.Models
{
    public class HomePageViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string BrandImgUrl { get; set; }
        public bool IsPreferred { get; set; }
    }
}