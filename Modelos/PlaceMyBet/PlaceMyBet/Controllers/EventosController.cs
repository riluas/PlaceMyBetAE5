using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventoRepository();
            List<EventoDTO> e = repo.Retrieve();
            return e;
        }
        /*** Ejercicio 1 ***/
        // GET: api/Eventos?Nombre=nombre
        public IEnumerable<Evento> Get(string Nombre)
        {
            var repo = new EventoRepository();
            
            List<Evento> e = repo.Exget(Nombre);
            return e;
        }
        /*** Fin Ejercicio 1 ***/

        // GET: api/Eventos?IdEvento=id&TipoM=tipo
        public Mercado GetMercado(int IdEvento, double TipoM)
        {
            var repom = new MercadoRepository();

            Mercado e = repom.Mget(IdEvento, TipoM);
            return e;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            Debug.WriteLine("evento val" + evento);
            var repo = new EventoRepository();
            repo.Save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]Evento evento)
        {
            var repo = new EventoRepository();
            repo.Edit(id,evento);
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new EventoRepository();
            repo.eRemove(id);
        }
    }
}
