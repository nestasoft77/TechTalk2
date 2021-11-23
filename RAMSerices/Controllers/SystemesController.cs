using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAMSerices.Entites;
using RAMSerices.Referentiels;

namespace RAMSerices.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SystemesController : Controller
    {

        private readonly SystemeReferentiel referentiel;

        public SystemesController()
        {
            referentiel = new SystemeReferentiel();
        }

        
        // Get /systemes
        [HttpGet]
        public IEnumerable<Systeme> ObtenirLesSystemes()
        {
            return referentiel.ObtenirLesSystemes();
        }

        
        // Get /systemes/{id}
        [HttpGet("id")]
        public ActionResult<Systeme> ObtenirUnSysteme(int id)
        {
            var sys = referentiel.ObtenirUnSysteme(id);

            if (sys is null)
                return NotFound();

            return sys;
        }

        // POST /systeme
        [HttpPost("cao")]
        public IEnumerable<Systeme>  ModifSysteme(int id, string cao)
        {
            return referentiel.ModificationSysteme(id, cao);
        }

        [HttpPut("systeme")]
        public IEnumerable<Systeme> AjoutSysteme(Systeme nSys)
        {
            Systeme nouveauSysteme = new()
            {
                Id = nSys.Id,
                Nom = nSys.Nom,
                CAO = nSys.CAO,
                Developpeurs = nSys.Developpeurs,
                DateAjout = nSys.DateAjout
            };

            return referentiel.AjoutSysteme(nouveauSysteme);

        }

        // Post /Systemes/{id}
        [HttpDelete("id")]
        public IEnumerable<Systeme> Delete(int id)
        {
            return referentiel.SupprimerSysteme(id);
        }

    }
}
