using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entidades;
using WebApiDados.Contexto;

namespace WebApiDados.Repositorio
{
    public sealed class AlunoRepositorio
    {
        SqlConnection _conexao = new SqlConnection(Conexao.ConexaoLyceum);
        public Aluno PesquisarPorCodigo(string codigo)
        {
            var resultado = this._conexao.Query<dynamic>(ScriptAluno.ObterAluno, new { codigo }).SingleOrDefault();            

            var dados = new Aluno();

            if (resultado == null)
                return dados;

            dados.Id = resultado.Id;
            dados.Nome = resultado.Nome;
            dados.Serie = resultado.Serie;
            dados.Curriculo = new Curriculo
            {
                Id = resultado.Curriculo,
                Turno = new Turno { Descricao = resultado.Turno },
                Curso = new Curso { Id = resultado.Curso, Nome = resultado.NomeCurso }                

            };
            dados.Unidade = new UnidadeFisica { Id = resultado.UnidadeFisica, Nome = resultado.NomeUnidade };
            dados.SituacaoAluno = resultado.SituacaoAluno;
            dados.TipoIngresso = resultado.TipoIngresso;
            dados.IngressoEm = resultado.Ingresso_Em;

            return dados;
        }

        public Aluno PesquisarPorCodigoHistorico(string codigo)
        {
            var _aluno = PesquisarPorCodigo(codigo);
            var dadosHist = new Aluno();

            if (_aluno.Id == null)
                return dadosHist;

            var resultado = this._conexao.Query<dynamic>(@"", new { codigo }).ToList();
            var dados = new List<Historico>();
            string NotaHis = null;

            foreach (var item in resultado)
            {
                NotaHis = item.MEDIA;

                dados.Add(new Historico
                {                    
                    DescricaoPeriodo = item.PERIODO,
                    Disciplina = new Disciplina
                    {
                        Id = item.DISCIPLINA,
                        Nome = item.NOME_DISCIPLINA,
                        Creditos = item.CARGA_HORARIA == "" || item.CARGA_HORARIA == null ? 0 : Convert.ToInt32(item.CARGA_HORARIA)
                    },
                    Nota = item.MEDIA,
                    Serie = Convert.ToString(item.SERIE),
                    Situacao = item.SITUACAO
                });
            }
            
            dadosHist.Id = codigo;
            dadosHist.Historicos = dados;

            return dadosHist;
        }

        public Aluno PesquisarPorCodigoNotas(string codigo)
        {
            var _aluno = PesquisarPorCodigo(codigo);

            var dadosMatr = new Aluno();

            if (_aluno.Id == null)
                return dadosMatr;

            var resultado = this._conexao.Query<dynamic>(ScriptAluno.ObterNotas, new { codigo }).ToList();

            var dados = new List<Nota>();
            foreach (var item in resultado)
            {
                dados.Add(new Nota
                {
                    Disciplina = new Disciplina { Id = item.DISCIPLINA, Nome = item.NOME_COMPL },
                    Turma = item.TURMA,
                    Ano = item.ANO,
                    Periodo = item.SEMESTRE,
                    Conceito = item.CONCEITO,
                    Prova = item.PROVA,
                    DescricaoProva = item.NOME_PROVA,
                    SitDetalhe = item.SIT_DETALHE
                });
            }
            
            dadosMatr.Id = codigo;
            dadosMatr.Notas = dados;            

            return dadosMatr;
        }

        public Aluno PesquisarPorCodigoAvisos(string codigo)
        {
            var _aluno = PesquisarPorCodigo(codigo);

            var dadosAviso = new Aluno();

            if (_aluno.Id == null)
                return dadosAviso;

            var resultado = this._conexao.Query<dynamic>(ScriptAluno.ObterAvisos, new { codigo }).ToList();

            var dados = new List<Aviso>();
            foreach (var item in resultado)
            {
                dados.Add(new Aviso
                {
                    DataInicio = item.DATA_INICIO,
                    Mensagem = item.MENSAGEM
                });
            }

            dadosAviso.Id = codigo;
            dadosAviso.Avisos = dados;

            return dadosAviso;
        }
    }
}
