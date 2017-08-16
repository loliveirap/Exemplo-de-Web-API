using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Entidades;
using WebApi.Models;
using WebApiDados.Repositorio;

namespace WebApi.Controllers
{
    public class HistoricoController : ApiController
    {
        private readonly AlunoRepositorio _servicoAluno = new AlunoRepositorio();
        
        public HistoricoModel GetAluno(string id)
        {
            var aluno = _servicoAluno.PesquisarPorCodigoHistorico(id);

            var _historico = new HistoricoModel(aluno);

            if (_historico.series == null)
            {
                _historico.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _historico;
        }
    }
}
