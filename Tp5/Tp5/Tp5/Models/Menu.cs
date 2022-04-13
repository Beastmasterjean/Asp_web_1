using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp5.Models
{
    public class Menu
    {
        int id { get; set; }
        string nom { get; set; }

        public Menu()
        {

        }
        public Menu(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
    }
}
