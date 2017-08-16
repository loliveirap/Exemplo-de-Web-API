using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Curso
    {
        public  string Id { get; set; }

        public  string Mnemonico { get; set; }

        public  string Nome { get; set; }

        public  string Habilitacao { get; set; }

        public  string Ativo { get; set; }

        public  string Tipo { get; set; }
    }
}
