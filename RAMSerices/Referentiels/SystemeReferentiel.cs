using RAMSerices.Entites;

namespace RAMSerices.Referentiels
{
    public class SystemeReferentiel
    {
        private readonly List<Systeme> SysList = new()
        {
            new Systeme { Id = 1, Nom = "ASF", CAO = "Francine Rochette", Developpeurs = new() { "Jean", "Pierre" }, DateAjout = DateTimeOffset.UtcNow },
            new Systeme { Id = 2, Nom = "CAC", CAO = "Sylvain Carrier", DateAjout = DateTimeOffset.UtcNow },
            new Systeme { Id = 3, Nom = "MSI", CAO = "François Trépanier", DateAjout = DateTimeOffset.UtcNow },
            new Systeme { Id = 4, Nom = "ECS", CAO = "Dany Coté", DateAjout = DateTimeOffset.UtcNow }
        };

        public  IEnumerable<Systeme> ObtenirLesSystemes()
        {
            return SysList;
        }

        public Systeme ObtenirUnSysteme(int id)
        {
            var sys = SysList.Where(systeme => systeme.Id == id).SingleOrDefault();
            return sys;
        }

        /// <summary>
        /// Modificaiton du cao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cao"></param>
        /// <returns></returns>
        public IEnumerable<Systeme> ModificationSysteme (int id, string cao)
        {
            return SysList.Where(s => s.Id == id).Select(s => { s.CAO = cao; return s; }).ToList();
        }

        /// <summary>
        /// Ajout d'un nouveau système
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public IEnumerable<Systeme> AjoutSysteme(Systeme sys)
        {
            SysList.Add(sys);
            return SysList;
        }
        /// <summary>
        /// Supression d'un système
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Systeme> SupprimerSysteme(int id)
        {
            SysList.RemoveAll(sys => sys.Id == id);
            return SysList;
        }



    }
}
