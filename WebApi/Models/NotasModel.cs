using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entidades;

namespace WebApi.Models
{
    public class NotasModel
    {
        public AlunoNotasModel notas { get; set; }
        public string erro { get; set; }

        public NotasModel(Aluno _aluno)
        {
            if (_aluno.Id != null)
            {
                var _disciplinas = (from d in _aluno.Notas
                                    select new
                                    {
                                        //IdAluno = d.Aluno.Id,
                                        IdDisciplina = d.Disciplina.Id,
                                        NomeDisciplina = d.Disciplina.Nome,
                                        Turma = d.Turma,
                                        Ano = d.Ano,
                                        Periodo = d.Periodo,
                                        SitDetalhe = d.SitDetalhe
                                    }).Distinct();

                var dadosMatricula = new List<MatriculaModel>();

                foreach (var listaDisciplina in _disciplinas)
                {
                    dadosMatricula.Add(new MatriculaModel
                    {
                        codigo = listaDisciplina.IdDisciplina,
                        nomedisciplina = listaDisciplina.NomeDisciplina,
                        notas = (from d in _aluno.Notas
                                 where d.Disciplina.Id == listaDisciplina.IdDisciplina
                                 && d.Turma == listaDisciplina.Turma
                                 && d.Ano == listaDisciplina.Ano
                                 & d.Periodo == listaDisciplina.Periodo
                                 select new ProvaModel
                                 {
                                     codigonota = d.Prova,
                                     descricaonota = d.DescricaoProva,
                                     valornota = d.Conceito
                                 }).Distinct().ToList()
                    });
                }

                var _notas = new AlunoNotasModel();
                _notas.aluno = _aluno.Id;
                _notas.disciplinas = dadosMatricula;

                notas = _notas;
                erro = "0";
            }
        }

    }

    public class AlunoNotasModel
    {
        public string aluno { get; set; }
        public List<MatriculaModel> disciplinas { get; set; }
    }
    public class MatriculaModel
    {
        public string codigo { get; set; }
        public string nomedisciplina { get; set; }        
        public List<ProvaModel> notas { get; set; }
    }

    public class ProvaModel
    {
        public string codigonota { get; set; }
        public string descricaonota { get; set; }
        public string valornota { get; set; }
    }


}