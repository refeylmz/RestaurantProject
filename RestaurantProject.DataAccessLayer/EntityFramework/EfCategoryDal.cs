using RestaurantProject.DataAccessLayer.Abstract;
using RestaurantProject.DataAccessLayer.Concrete;
using RestaurantProject.DataAccessLayer.Repositories;
using RestaurantProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(RestaurantProjectContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new RestaurantProjectContext();
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new RestaurantProjectContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new RestaurantProjectContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
