using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entidades;
using WebApiDados.Contexto;
using Dapper;
using System.Data.SqlClient;
using WebApi.Entidades.ObjetoValor;

namespace WebApiDados.Repositorio
{
    public sealed class PessoaRepositorio
    {        
        SqlConnection _conexao = new SqlConnection(Conexao.ConexaoLyceum);
        public Pessoa PesquisarPorCodigo(string codigo)
        {
            var resultado = this._conexao.Query<dynamic>(ScriptPessoa.ObterPessoa, new { codigo }).SingleOrDefault();
            var pessoa = new Pessoa();

            if (resultado == null)
                return pessoa;

            pessoa.Id = resultado.PESSOA;
            pessoa.Nome = resultado.NOME_COMPL;
            pessoa.Apelido = resultado.NOME_ABREV;
            pessoa.RG = new RG
            {
                Numero = resultado.RG_NUM,
                OrgaoEmissor = resultado.RG_EMISSOR,
                UF = resultado.RG_UF,
                Expedicao = resultado.RG_DTEXP,
                CPF = resultado.CPF,
                Certidao = new Certidao
                {
                    Pai = resultado.NOME_PAI,
                    Mae = resultado.NOME_MAE,
                    Data = resultado.DT_NASC,
                    Pais = resultado.PAIS_NASC,
                    Nacionalidade = resultado.NACIONALIDADE,
                    Folha = resultado.CERT_NASC_FOLHA,
                    Livro = resultado.CERT_NASC_LIVRO,
                    Cartorio = resultado.CERT_NASC_CARTORIO_EXPED,
                    Emissao = resultado.CERT_NASC_EMISSAO,
                    Raca = resultado.COR_RACA,
                    Numero = resultado.CERT_NASC_NUM,
                    Municipio = new Municipio
                    {
                        UF = resultado.CERT_NASC_CARTORIO_UF,
                        Nome = resultado.NOME_MUNICIPIO_NASC
                    }
                }
            };
            pessoa.Sexo = resultado.SEXO == "M" ? "Masculino" : "Feminino" ;
            pessoa.EstadoCivil = resultado.EST_CIVIL;
            pessoa.Endereco = new Endereco
            {
                Confirmado = resultado.END_CORRETO,
                Logradouro = resultado.ENDERECO,
                Numero = resultado.END_NUM,
                Complemento = resultado.END_COMPL,
                Bairro = resultado.BAIRRO,
                Municipio = new Municipio { Nome = resultado.NOME_END_MUNICIPIO, Estado = resultado.ESTADO },
                Pais = resultado.END_PAIS,
                CEP = resultado.CEP,
                Contato = new Contato
                {
                    Telefone = new Telefone { DDD = resultado.DDD_FONE, Numero = resultado.FONE },
                    Celular = new Telefone { DDD = resultado.DDD_FONE_CELULAR, Numero = resultado.CELULAR },
                    Recado = new Telefone { DDD = resultado.DDD_FONE_RECADO, Numero = resultado.OBS_TEL_REC },
                    Fax = new Telefone { DDD = resultado.DDD_FAX_RES, Numero = resultado.FAX_RES }
                }
            };
            pessoa.TituloEleitoral = new TituloEleitoral
            {
                Numero = resultado.TELEITOR_NUM,
                Secao = resultado.TELEITOR_SECAO,
                Zona = resultado.TELEITOR_ZONA,
                Expedicao = resultado.TELEITOR_DTEXP,
                Municipio = new Municipio { Id = resultado.NOME_TELEITOR_MUN, UF = "" }
            };
            pessoa.Profissao = new Profissao
            {
                Numero = resultado.CPROF_NUM,
                Expedicao = resultado.CPROF_DTEXP,
                Serie = resultado.CPROF_SERIE,
                UF = resultado.CPROF_UF,

                Cargo = resultado.PROFISSAO,
                ConselhoRegional = resultado.CONSELHO_REGIONAL,
                Empresa = resultado.NOME_EMPRESA,

                Endereco = new Endereco
                {
                    Pais = resultado.ENDCOM_PAIS,
                    Municipio = new Municipio
                    {
                        Id = resultado.ENDCOM_MUNICIPIO,
                    },

                    CEP = resultado.ENDCOM_CEP,
                    Bairro = resultado.ENDCOM_BAIRRO,
                    Complemento = resultado.ENDCOM_COMPL,
                    Logradouro = resultado.ENDCOM,
                    Numero = resultado.ENDCOM_NUM,

                },
                Contato = new Contato
                {
                    Telefone = new Telefone { DDD = resultado.FONE_COM, Numero = resultado.DDD_FONE_COMERCIAL },
                },
                Area = resultado.AREA_PROF,
                Especializacao = resultado.ESPECIALIZACAO
            };
            pessoa.Reservista = new Reservista
            {
                Numero = resultado.CR_NUM,
                RM = resultado.CR_RM,
                Serie = resultado.CR_SERIE,
                CSM = resultado.CR_CSM,
                Expedicao = resultado.CR_DTEXP
            };
            pessoa.Reservista = new Reservista
            {
                Numero = resultado.ALIST_NUM,
                RM = resultado.ALIST_RM,
                Serie = resultado.ALIST_SERIE,
                CSM = resultado.ALIST_CSM,
                Expedicao = resultado.ALIST_DTEXP,

            };
            pessoa.Observacao = new Observacoes
            {
                MailBox = resultado.MAILBOX,
                Email = resultado.E_MAIL_INTERNO,
                Data = resultado.DT_FALECIMENTO,
                DividaBiblioteca = resultado.DIVIDA_BIBLIO,
                Observacao = resultado.OBS,
                Renda = resultado.RENDA_MENSAL,
                CorRaca = resultado.COR_RACA,
                NecessidadeEspecial = resultado.NECESSIDADE_ESPECIAL,
                EnviarEmail = resultado.AUTORIZA_ENVIO_MAIL
            };

            pessoa.Responsavel = new Responsavel
            {
                Nome = resultado.RESP_NOME_COMPL,
                Sexo = resultado.RESP_SEXO,
                EstadoCivil = resultado.RESP_EST_CIVIL,
                Endereco = new Endereco
                {
                    Logradouro = resultado.RESP_ENDERECO,
                    Numero = resultado.RESP_END_NUM,
                    Bairro = resultado.RESP_BAIRRO,
                    CEP = resultado.RESP_CEP,
                    Complemento = resultado.RESP_END_COMPL,

                    Municipio = new Municipio
                    {
                        Id = resultado.NOME_MUNICIPIO_RESP,
                        UF = resultado.UF_RESP
                    },
                    Contato = new Contato
                    {
                        Telefone = { DDD = resultado.DDD_RESP_FONE, Numero = resultado.RESP_FONE },
                    },
                    Pais = resultado.RESP_END_PAIS
                },
                RG = new RG
                {
                    Numero = resultado.RESP_RG_NUM,
                    Certidao = new Certidao { Nacionalidade = resultado.RESP_NACIONALIDADE }
                }
            };

            return pessoa;
        }
    }
}
