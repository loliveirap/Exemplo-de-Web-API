using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entidades;

namespace WebApi.Models
{
    public class PessoaModel
    {
        public DadosPessoaisModel dadospessoais { get; set; }
        public string erro { get; set; }

        public PessoaModel(Pessoa _pessoa)
        {
            if(_pessoa.Nome != null)
            {
                var _dadospessoais = new DadosPessoaisModel();
                _dadospessoais.nomealuno = _pessoa.Nome;
                _dadospessoais.rg = _pessoa.RG.Numero;
                _dadospessoais.ufrg = _pessoa.RG.UF;
                _dadospessoais.cpf = _pessoa.RG.CPF;
                _dadospessoais.tituloeleitor = _pessoa.TituloEleitoral.Numero;
                _dadospessoais.email = _pessoa.Observacao.MailBox;
                _dadospessoais.datanascimento = _pessoa.RG.Certidao.Data;
                _dadospessoais.sexo = _pessoa.Sexo;
                _dadospessoais.naturalidade = _pessoa.RG.Certidao.Municipio.Nome;
                _dadospessoais.certificadomilitar = _pessoa.Reservista.Numero;
                _dadospessoais.mae = _pessoa.RG.Certidao.Mae;
                _dadospessoais.endereco = _pessoa.Endereco.Logradouro + " " + _pessoa.Endereco.Numero + " " + _pessoa.Endereco.Complemento;
                _dadospessoais.cidade = _pessoa.Endereco.Municipio.Nome;
                _dadospessoais.bairro = _pessoa.Endereco.Bairro;
                _dadospessoais.cep = _pessoa.Endereco.CEP;
                _dadospessoais.estado = _pessoa.Endereco.Municipio.Estado;
                _dadospessoais.telefoneresidencial = _pessoa.Endereco.Contato.Telefone.DDD + " " + _pessoa.Endereco.Contato.Telefone.Numero;
                _dadospessoais.telefonecomercial = _pessoa.Profissao.Contato.Telefone.DDD + " " + _pessoa.Profissao.Contato.Telefone.Numero;

                dadospessoais = _dadospessoais;
                erro = "0";
            }
        }
    }

    public class DadosPessoaisModel
    {
        public string nomealuno { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string ufrg { get; set; }
        public string tituloeleitor { get; set; }
        public string email { get; set; }
        public string datanascimento { get; set; }
        public string sexo { get; set; }
        public string naturalidade { get; set; }
        public string certificadomilitar { get; set; }
        public string mae { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
        public string telefoneresidencial { get; set; }
        public string telefonecomercial { get; set; }
    }
}