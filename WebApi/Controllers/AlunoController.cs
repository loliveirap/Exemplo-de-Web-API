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
    public class AlunoController : ApiController
    {
        private readonly AlunoRepositorio _servicoAluno = new AlunoRepositorio();
        public AlunoModel GetAluno(string id)
        {
            var aluno = _servicoAluno.PesquisarPorCodigo(id);

            var _aluno = new AlunoModel(aluno);

            if (_aluno.dadosacademicos == null)
            {
                _aluno.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _aluno;
        }

    }
}
