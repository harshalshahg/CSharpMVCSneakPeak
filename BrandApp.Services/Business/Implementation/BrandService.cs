using BrandApp.Services.Domain.Model;
using BrandApp.Services.Integration.Implementation.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Business.Implementation
{
    public class BrandService
    {
        public static List<Brand> GetAllBrands()
        {
            List<Brand> brands = new List<Brand>();
            using (CustomContext ctx = new CustomContext())
            {
                brands = ctx.BrandTable.ToList();
            }
            return brands;
        }

        public static List<int> GetPreferredBrandIds(int UserId)
        {
            List<int> brandIds = new List<int>();
            using (CustomContext ctx = new CustomContext())
            {
                brandIds = ctx.UserBrandTable
                    .Where(a => a.UserId == UserId)
                    .Select(b => b.BrandId).ToList();
            }
            return brandIds;
        }

        public static Brand GetBrandDetailsById(int BrandId)
        {
            Brand brand = new Brand();
            using (CustomContext ctx = new CustomContext())
            {
                brand = ctx.BrandTable
                    .Where(a=>a.Id == BrandId)
                    .FirstOrDefault();
            }
            return brand;
        }

        public static bool isSelectedBrandPreferred(int brandId, int userId)
        {
            int recordCount = 0;
            using (CustomContext ctx = new CustomContext())
            {
               recordCount = ctx.UserBrandTable
                    .Where(a => a.BrandId == brandId)
                    .Where(b => b.UserId == userId)
                    .Count();
            }
            return recordCount > 0 ? true : false;
        }

        public static bool AddBrandToPrefered(int brandId, int userId)
        {
            int rowsAdded = 0;
            UserBrand userBrand = new UserBrand();
            userBrand.BrandId = brandId;
            userBrand.UserId = userId;

            using (CustomContext ctx = new CustomContext())
            {
                ctx.UserBrandTable.Add(userBrand);
                rowsAdded = ctx.SaveChanges();
            }
            return rowsAdded > 0 ? true : false; 
        }

        public static bool RemoveBrandFromPrefered(int brandId, int userId)
        {
            int rowsRemoved = 0;
            using (CustomContext ctx = new CustomContext())
            {
               UserBrand userBrandForDelete =  ctx.UserBrandTable
                                    .Where(a => a.BrandId == brandId)
                                    .Where(b => b.UserId == userId)
                                    .FirstOrDefault();
               ctx.UserBrandTable.Remove(userBrandForDelete);
               rowsRemoved = ctx.SaveChanges();
            }
            return rowsRemoved > 0 ? true : false;
        }
    }
}
