using RestaurantProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.BusinessLayer.Abstract
{
    public interface IBasketService:IGenericService<Basket>
    {
        object TGetBasketByMenuTableID(int id);
        List<Basket> TGetBasketByMenuTableNumber(int id);
    }
}
