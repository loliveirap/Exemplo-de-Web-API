using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entidades;

namespace WebApi.Models
{
    public class AlunoModel
    {
        public DadosAcademicosModel dadosacademicos { get; set; }

        public string erro { get; set; }

        public AlunoModel(Aluno _aluno)
        {
            if (_aluno.Nome != null)
            {
                var _dadosAcademicos = new DadosAcademicosModel();

                _dadosAcademicos.ra = _aluno.Id;
                _dadosAcademicos.nome = _aluno.Nome;
                _dadosAcademicos.ingressoem = _aluno.IngressoEm;
                _dadosAcademicos.curriculo = _aluno.Curriculo.Id;
                _dadosAcademicos.curso = _aluno.Curriculo.Curso.Id;
                _dadosAcademicos.nomecurso = _aluno.Curriculo.Curso.Nome;
                _dadosAcademicos.turno = _aluno.Curriculo.Turno.Descricao;
                _dadosAcademicos.serie = Convert.ToString(_aluno.Serie);
                _dadosAcademicos.situacaoaluno = _aluno.SituacaoAluno;
                _dadosAcademicos.unidadefisica = _aluno.Unidade.Id;
                _dadosAcademicos.nomeunidadefisica = _aluno.Unidade.Nome;
                

                dadosacademicos = _dadosAcademicos;
                erro = "0";
            }            
        }
    }
    public class DadosAcademicosModel
    {
        public string ra { get; set; }
        public string nome { get; set; }
        public string ingressoem { get; set; }
        public string curriculo { get; set; }
        public string curso { get; set; }
        public string nomecurso { get; set; }
        public string turno { get; set; }
        public string serie { get; set; }
        public string situacaoaluno { get; set; }
        public string unidadefisica { get; set; }
        public string nomeunidadefisica { get; set; }
    }
}