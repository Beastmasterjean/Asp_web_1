using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp5.Models
{
    public class Reservation
    {
        int id { get; set; }
        int nbPersonne { get; set; }
        int menuChoiceId { get; set; }
        string nom { get; set; }
        string courriel { get; set; }
        DateTime date { get; set; }

        public Reservation()
        {

        }
        public Reservation(int id, int nbPersonne, int menuChoiceId, string nom, string courriel, DateTime date)
        {
            this.id = id;
            this.nbPersonne = nbPersonne;
            this.menuChoiceId = menuChoiceId;
            this.nom = nom;
            this.courriel = courriel;
            this.date = date;
        }
    }
}
