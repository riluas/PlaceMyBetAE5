using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuesta> Get()
        {
            var repo = new ApuestaRepository();
            List<Apuesta> a = repo.Retrieve();
            return a;
        }

        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve2(id);
            return a;
        }

        // GET: api/Apuestas/?eUsu=email&tipoM=tipo
        [Authorize(Roles ="Admin")]
        public IEnumerable<ApuestaUsu> GetApuestaUsu(string eUsu, double tipoM)
        {

            var repo = new ApuestaRepository();
            List<ApuestaUsu> apuestaUsu = repo.GetApuestaUsu(eUsu, tipoM);
            return apuestaUsu;

        }

        // GET: api/Apuestas/?tipoM=tipo&eUsu=email
        public IEnumerable<ApuestaMUsu> GetApuestaMUsu(double tipoEm, string emUsu)
        {

            var repo = new ApuestaRepository();
            List<ApuestaMUsu> apuestaMUsu = repo.GetApuestaMUsu(tipoEm, emUsu);
            return apuestaMUsu;

        }


        // POST: api/Apuestas
        [Authorize]
        public void Post([FromBody] ApuestaDTO apuesta)
        {

            var repo = new ApuestaRepository();
            var repo2 = new MercadoRepository();
            double tipo = repo.Cuota(apuesta);
            repo.Save(apuesta, tipo);
            repo2.dineroUpdate(apuesta);
            MercadoCuota cUpdate = repo2.cuotaUpdate();
            repo2.calc(cUpdate);

        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
