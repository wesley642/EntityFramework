using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRUD_EntityFramework_Ti32
{
    public class Agenda
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }

        public string CEP { get; set; }

        public double Salario { get; set; }
    }
}
