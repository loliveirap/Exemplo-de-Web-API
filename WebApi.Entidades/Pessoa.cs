using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entidades.ObjetoValor;

namespace WebApi.Entidades
{
    public class Pessoa
    {        
        public decimal Id { get; set; }

        public string Apelido { get; set; }

        public string Nome { get; set; }
        
        public virtual string Email { get; set; }

        public string Sexo { get; set; }
        
        public string EstadoCivil { get; set; }

        private Endereco _endereco;
        public virtual Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value ?? new Endereco(); }
        }

        private RG _rg;
        public virtual RG RG
        {
            get { return _rg; }
            set { _rg = value ?? new RG(); }
        }

        private Reservista _reservista;
        public virtual Reservista Reservista
        {
            get { return _reservista; }
            set { _reservista = value ?? new Reservista(); }
        }

        private Reservista _militar;
        public virtual Reservista Militar
        {
            get { return _militar; }
            set { _militar = value ?? new Reservista(); }
        }

        private TituloEleitoral _tituloEleitoral;
        public virtual TituloEleitoral TituloEleitoral
        {
            get { return _tituloEleitoral; }
            set { _tituloEleitoral = value ?? new TituloEleitoral(); }
        }

        private Profissao _profissao;
        public virtual Profissao Profissao
        {
            get { return _profissao; }
            set { _profissao = value ?? new Profissao(); }
        }

        private Observacoes _observacoes;
        public virtual Observacoes Observacao
        {
            get { return _observacoes; }
            set { _observacoes = value ?? new Observacoes(); }
        }

        private Responsavel _responsavel;
        public virtual Responsavel Responsavel
        {
            get { return _responsavel; }
            set { _responsavel = value ?? new Responsavel(); }
        }
        public Pessoa()
        {            
            this.RG = new RG();
            this.Endereco = new Endereco();
            this.TituloEleitoral = new TituloEleitoral();
            this.Reservista = new Reservista();
            this.Profissao = new Profissao();
            this.Observacao = new Observacoes();
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
