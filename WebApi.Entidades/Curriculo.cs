using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Curriculo
    {
        public  string Id { get; set; }
        public  Curso Curso { get; set; }
        public  Turno Turno { get; set; }
    }
}
