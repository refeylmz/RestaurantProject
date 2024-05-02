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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(RestaurantProjectContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new RestaurantProjectContext();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new RestaurantProjectContext();
            return context.Notifications.Where(x => x.Status == false).Count();
        }

		public void NotificationStatusChangeToFalse(int id)
		{
			using var context = new RestaurantProjectContext();
			var value = context.Notifications.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
            using var context = new RestaurantProjectContext();
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
		}
	}
}
