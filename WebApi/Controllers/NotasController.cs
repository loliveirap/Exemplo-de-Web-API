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
    public class NotasController : ApiController
    {
        private readonly AlunoRepositorio _servicoAluno = new AlunoRepositorio();
        public NotasModel GetAluno(string id)
        {
            var aluno = _servicoAluno.PesquisarPorCodigoNotas(id);

            var _notas = new NotasModel(aluno);

            if (_notas.notas == null)
            {
                _notas.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _notas;
        }
    }
}
