using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class Historico
    {        

        public Disciplina Disciplina { get; set; }

        public string Turma { get; set; }

        public decimal? Ano { get; set; }

        public decimal? Periodo { get; set; }

        public string DescricaoPeriodo { get; set; }

        public decimal? Ordem { get; set; }

        public string Serie { get; set; }

        private string _nota;
        public virtual string Nota
        {
            get { return this._nota; }
            set
            {
                this._nota = value ?? string.Empty;
                if (Regex.IsMatch(this._nota, @"[,|\.]|[0-9]"))
                {
                    this._nota = Regex.Replace(this._nota.Trim(), @"^\.|^,", "0,");
                    this._nota = Regex.Replace(this._nota, @"\.", ",");
                    this._nota = string.Format("{0:00.00}", Decimal.Parse(this._nota));
                }
            }
        }
                
        public string Situacao { get; set; }

        public decimal? Frequencia { get; set; }
    }
}
