using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new MercadoRepository();
            List<Mercado> m = repo.Retrieve();
            return m;
        }

        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            var repo = new MercadoRepository();
            Mercado m = repo.Retrieve2(id);
            return m;
        }

        /*public MercadoDTO Get(int id)
        {
            var repo = new MercadoRepository();
            MercadoDTO m = repo.Retrieve();
            return m;
        }*/

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
