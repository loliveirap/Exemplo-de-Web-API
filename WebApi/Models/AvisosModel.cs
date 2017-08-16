using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entidades;

namespace WebApi.Models
{
    public class AvisosModel
    {
        public IEnumerable<ListaAvisosModel> avisos { get; set; }
        public string erro { get; set; }

        public AvisosModel(Aluno _aluno)
        {
            if (_aluno.Id != null)
            {
                var _avisos = new List<ListaAvisosModel>();

                foreach(var listaAviso in _aluno.Avisos)
                {
                    _avisos.Add(new ListaAvisosModel
                    {
                        data = listaAviso.DataInicio,
                        mensagem = listaAviso.Mensagem
                    });
                }

                avisos = _avisos;
                erro = "0";
            }
            
        }
    }

    public class ListaAvisosModel
    {
        public string data { get; set; }
        public string mensagem { get; set; }
    }


}