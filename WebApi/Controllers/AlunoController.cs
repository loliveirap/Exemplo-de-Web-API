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
    [RoutePrefix("Aluno")]
    public class AlunoController : ApiController
    {
        private readonly AlunoRepositorio _repositorioAluno = new AlunoRepositorio();
        private readonly PessoaRepositorio _servicoPessoa = new PessoaRepositorio();

        // Rota: /Aluno/{id}
        [Route("{id}")]
        public HttpResponseMessage Get([FromUri]string id)
        {
            var aluno = _repositorioAluno.PesquisarPorCodigo(id);

            var _aluno = new AlunoModel(aluno);

            if (_aluno.dadosacademicos == null)
            {
                _aluno.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                return Request.CreateResponse(HttpStatusCode.NotFound, _aluno.erro);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _aluno);
        }

        // Rota: /Aluno/{id}/DadosPessoais
        [Route("{id}/DadosPessoais")]
        public HttpResponseMessage GetDadosPessoais([FromUri]string id)
        {
            var pessoa = _servicoPessoa.PesquisarPorCodigo(id);

            var _pessoa = new PessoaModel(pessoa);

            if (_pessoa.dadospessoais == null)
            {
                _pessoa.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                return Request.CreateResponse(HttpStatusCode.NotFound, _pessoa.erro);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _pessoa);
        }

        // Rota: /Aluno/{id}/Notas
        [Route("{id}/Notas")]
        public HttpResponseMessage GetNotas([FromUri]string id)
        {
            var aluno = _repositorioAluno.PesquisarPorCodigoNotas(id);

            var _notas = new NotasModel(aluno);

            if (_notas.disciplinas == null)
            {
                _notas.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();                
                return Request.CreateResponse(HttpStatusCode.NotFound, _notas.erro);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _notas);
        }

        // Rota: /Aluno/{id}/Avisos
        [Route("{id}/Avisos")]
        public HttpResponseMessage GetAvisos([FromUri]string id)
        {
            var aluno = _repositorioAluno.PesquisarPorCodigoAvisos(id);

            var _avisos = new AvisosModel(aluno);

            if (_avisos.avisos == null)
            {
                _avisos.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                return Request.CreateResponse(HttpStatusCode.NotFound, _avisos.erro);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _avisos);
        }

        // Rota: /Aluno/{id}/Historico
        [Route("{id}/Historico")]
        public HttpResponseMessage GetHistorico(string id)
        {
            var aluno = _repositorioAluno.PesquisarPorCodigoHistorico(id);

            var _historico = new HistoricoModel(aluno);

            if (_historico.series == null)
            {
                _historico.erro = Request.CreateResponse(HttpStatusCode.NotFound).ToString();
                return Request.CreateResponse(HttpStatusCode.NotFound, _historico.erro);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _historico);
        }
    }
}

