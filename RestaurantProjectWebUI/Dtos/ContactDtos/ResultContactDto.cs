using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProjectWebUI.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; } // = "Efe's Restaurant";
        public string FooterDescription { get; set; }
        public string OpenDays { get; set; }// = "Çalışma Saatlerimiz";
        public string OpenDaysDescription { get; set; } //= "Haftanın 7 Günü Hizmetinizdeyiz";
        public string OpenHours { get; set; } //= "Sabah 10:00- Akşam 23:59";
    }
}
