﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EntityFramework_Ti32
{
    public class SalaAula
    {
        public int id { get; set; }
        public string Professor { get; set; }
        public string Sala { get; set; }

        public string Curso { get; set; }

        public DateTime Data { get; set; }
    }
}
