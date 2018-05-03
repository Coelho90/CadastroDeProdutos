using Projeto.Entities;
using Projeto.Entities.Enum;
using Projeto.Infra.Data;
using Projeto.Services.Models;
using Projeto.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Services.Controllers
{

    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(ProdutoCadastroViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto p = new Produto();
                    p.Nome = model.Nome;
                    p.Preco = model.Preco;
                    p.Quantidade = model.Quantidade;
                    p.DataCompra = DateTime.Now;
                    p.Status = (Status) model.Status;

                    ProdutoRepositorio rep = new ProdutoRepositorio();

                    rep.Insert(p);

                    return Request.CreateResponse(HttpStatusCode.OK, "Produto cadastrado com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadGateway,  ValidationUtil.GetValidationErrors(ModelState));
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }

        }


    }
}
