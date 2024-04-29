using Microsoft.EntityFrameworkCore;
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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(RestaurantProjectContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {
            using var context = new RestaurantProjectContext();
            var values = context.Baskets.Where(x => x.MenuTableID == id).Include(y => y.Product).ToList();
            return  values;
        }
    }
}
