using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    /// <summary>
    /// 创建Web API控制器
    /// 有两个特征：
    /// 1. 动作方法返回的是模型对象，而不是ActionResult对象
    /// 2. 动作方法是根据请求所使用的HTTP方法来选择的
    /// API控制器的动作方法所返回的模型对象被编码成JSON，并发送给客户端
    /// 使用路径/api/web访问，例如：http://localhost:56044/api/web
    /// </summary>
    public class WebController : ApiController
    {
        private ReservationRespository repo = ReservationRespository.Crrent;
        public IEnumerable<Reservation> GetAllReservations()
        {
            return repo.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return repo.Add(item);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return repo.Update(item);
        }

        public void DeleteReservation(int id)
        {
            repo.Remove(id);
        }
    }
}
