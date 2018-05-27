using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entities;
using Projeto.Infra.Data.Repositories;
using Projeto.Services.Models;
using Projeto.Entities.Enums;
using Projeto.Services.Utils;


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
                    p.Status = (Status)model.Status;

                    ProdutoRepositorio rep = new ProdutoRepositorio();
                    rep.Insert(p); 

                    return Request.CreateResponse(HttpStatusCode.OK,
                            "Produto cadastrado com sucesso.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                            ValidationUtil.GetValidationErrors(ModelState));
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpGet]
        [Route("listartodos")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<ProdutoConsultaViewModel> lista = new List<ProdutoConsultaViewModel>();

                ProdutoRepositorio rep = new ProdutoRepositorio();
                foreach (Produto p in rep.FindAll())
                {
                    ProdutoConsultaViewModel model = new ProdutoConsultaViewModel();
                    model.IdProduto = p.IdProduto;
                    model.Nome = p.Nome;
                    model.Preco = p.Preco;
                    model.Quantidade = p.Quantidade;
                    model.Status = p.Status.ToString();
                    model.Total = p.Preco * p.Quantidade;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(ProdutoEdicaoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto p = new Produto();
                    p.IdProduto = model.IdProduto;
                    p.Nome = model.Nome;
                    p.Preco = model.Preco;
                    p.Quantidade = model.Quantidade;
                    p.Status = (Status)model.Status;
                    p.DataCompra = model.DataCompra;

                    ProdutoRepositorio rep = new ProdutoRepositorio();
                    rep.Update(p); 

                    return Request.CreateResponse(HttpStatusCode.OK,
                                    "Produto atualizado com sucesso");
                }
                else
                {
                    
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                            ValidationUtil.GetValidationErrors(ModelState));
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProdutoRepositorio rep = new ProdutoRepositorio();

                
                Produto p = rep.FindById(id);

               
                rep.Delete(p);

                
                return Request.CreateResponse(HttpStatusCode.OK,
                                "Produto excluído com sucesso");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                
                ProdutoRepositorio rep = new ProdutoRepositorio();
                Produto p = rep.FindById(id);

               
                ProdutoConsultaViewModel model = new ProdutoConsultaViewModel();
                model.IdProduto = p.IdProduto;
                model.Nome = p.Nome;
                model.Preco = p.Preco;
                model.Quantidade = p.Quantidade;
                model.Total = p.Preco * p.Quantidade;
                model.DataCompra = p.DataCompra;
                model.Status = p.Status.ToString();

                
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }




    }
}
