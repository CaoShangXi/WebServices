using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices.Models;

namespace WebServices.Models
{
    public class ReservationRespository
    {
        private static ReservationRespository repo = new ReservationRespository();
        public static ReservationRespository Crrent
        {
            get { return repo; }
        }
        private List<Reservation> data = new List<Reservation>
        {
            new Reservation{ReservationId=1,ClientName="Adam",Location="BoardRoom"},
            new Reservation{ReservationId=2,ClientName="Jacqui",Location="Lecture Hall"},
            new Reservation{ReservationId=3,ClientName="Russell",Location="Meetion Room 1"}
        };
        public IEnumerable<Reservation> GetAll()
        {
            return data;
        }

        public Reservation Get(int id)
        {
            return data.Where(x => x.ReservationId == id).FirstOrDefault();
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = data.Count()+ 1;
            data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item=Get(id);
            if (data!=null)
            {
                data.Remove(item);
            }
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem=Get(item.ReservationId);
            if (storedItem!=null)
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