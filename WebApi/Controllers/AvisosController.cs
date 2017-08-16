using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApiDados.Repositorio;

namespace WebApi.Controllers
{
    public class AvisosController : ApiController
    {
        private readonly AlunoRepositorio _servicoAluno = new AlunoRepositorio();
        
        //public HttpResponseMessage GetAluno(string id)
        public AvisosModel GetAluno(string id)
        {
            var aluno = _servicoAluno.PesquisarPorCodigoAvisos(id);

            var _avisos = new AvisosModel(aluno);

            if (_avisos.avisos == null)
            {
                _avisos.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            //return Request.CreateResponse(HttpStatusCode.OK, _avisos);
            return _avisos;
        }
    }
}
