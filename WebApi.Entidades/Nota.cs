using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Nota
    {
        public virtual Aluno Aluno { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        public virtual string Turma { get; set; }

        public virtual decimal? Ano { get; set; }

        public virtual decimal? Periodo { get; set; }

        public virtual string Prova { get; set; }

        public virtual string DescricaoProva { get; set; }

        public virtual string SitDetalhe { get; set; }

        private string _conceito;
        public virtual string Conceito
        {
            get { return this._conceito; }
            set
            {
                this._conceito = value ?? string.Empty;
                if (Regex.IsMatch(this._conceito, @"[,|\.]|[0-9]"))
                {
                    this._conceito = Regex.Replace(this._conceito.Trim(), @"^\.|^,", "0,");
                    this._conceito = Regex.Replace(this._conceito, @"\.", ",");
                    this._conceito = string.Format("{0:00.00}", Decimal.Parse(this._conceito));
                }
            }
        }
    }
}
