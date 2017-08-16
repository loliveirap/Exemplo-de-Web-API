using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entidades;

namespace WebApi.Models
{
    public class HistoricoModel
    {
        public IEnumerable<SerieHistoricoModel> series { get; set; }
        public string erro { get; set; }

        public HistoricoModel(Aluno _aluno)
        {
            if(_aluno.Id != null)
            {
                var _series = (from s in _aluno.Historicos
                               select new
                               {
                                   serie = s.Serie
                               }).Distinct();


                var _seriesHistorico = new List<SerieHistoricoModel>();

                foreach (var listaSerie in _series)
                {
                    _seriesHistorico.Add(new SerieHistoricoModel
                    {                        
                        disciplinas = (from d in _aluno.Historicos
                                       where d.Serie == listaSerie.serie
                                       select new DisciplinaHistoricoModel
                                       {
                                           codigo = d.Disciplina.Id,
                                           nomedisciplina = d.Disciplina.Nome,
                                           periodo = d.DescricaoPeriodo,
                                           situacao = d.Situacao,
                                           cargahoraria = Convert.ToString(d.Disciplina.Creditos),
                                           media = d.Nota
                                       }).Distinct().ToList(),
                        serie = listaSerie.serie
                    });
                }
                
                series = _seriesHistorico;
                erro = "0";
            }
        }
    }
    
    public class SerieHistoricoModel
    {        
        public IEnumerable<DisciplinaHistoricoModel> disciplinas { get; set; }
        public string serie { get; set; }
    }
    public class DisciplinaHistoricoModel
    {
        public string codigo { get; set; }
        public string nomedisciplina { get; set; }
        public string cargahoraria { get; set; }
        public string periodo { get; set; }
        public string media { get; set; }
        public string situacao { get; set; }
        
    }

}