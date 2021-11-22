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
        [HttpPost]
        public void AjoutSysteme(Systeme nSys)
        {
            Systeme nouveauSysteme = new()
            {
                Id = nSys.Id,
                Nom = nSys.Nom,
                CAO = nSys.CAO,
                Developpeurs = nSys.Developpeurs,
                DateAjout = nSys.DateAjout
            };

            referentiel.AjoutSysteme(nouveauSysteme);

        }

        // Post /Systemes/{id}
        [HttpPost("id")]
        public void Delete(int id)
        {
            referentiel.SupprimerSysteme(id);
        }

    }
}
