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
    public class PessoaController : ApiController
    {
        private readonly PessoaRepositorio _servicoPessoa = new PessoaRepositorio();
        public PessoaModel Get(string id)
        {
            var pessoa = _servicoPessoa.PesquisarPorCodigo(id);

            var _pessoa = new PessoaModel(pessoa);

            if (_pessoa.dadospessoais == null)
            {
                _pessoa.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _pessoa;
        }
    }
}
