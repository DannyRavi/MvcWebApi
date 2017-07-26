using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcWebApi.Models
{
    public class ReservationRepository 
    {
        private static ReservationRepository repo = new ReservationRepository();
        public static ReservationRepository Current {
            get { return repo; }
        }

        private List<Reservation> data = new List<Reservation> {
            new Reservation {ReservationId=1,ClientName="Danny_Khosravi",Location="tehran" },
            new Reservation {ReservationId=2,ClientName="saeed_tavakoly",Location="karaj" },
        };
        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int id)
        {
            return data.Where(x => x.ReservationId == id).FirstOrDefault();
        }

        public Reservation Add(Reservation item) {
            item.ReservationId = data.Count + 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
            {
                data.Remove(item);
            }
        }
        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}