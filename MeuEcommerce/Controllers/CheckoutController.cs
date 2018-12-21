using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace MeuEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public ActionResult Index()
        {
            var model = new CheckoutIndexViewModel();
            model.Carrinho = GetCarrinhoDaSessao();

                      
            return View(model);
        }

        public ActionResult Incrementa(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            CarrinhoItem item  = carrinho.Itens[id];
            item.Quantidade++;

            return Redirect("Index");

        }

        public ActionResult Decrementa(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            CarrinhoItem item = carrinho.Itens[id];
            item.Quantidade--;

            return Redirect("Index");
        }

        public ActionResult Remove(int id)
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            carrinho.Itens.Remove(id);

            return Redirect("Index");
        }

        [Authorize]
        public ActionResult CompraRealizada()
        {
            Carrinho carrinho = GetCarrinhoDaSessao();

            var compraItens = new List<Compras_Item>();

            foreach (var item in carrinho.Itens)
            {
                compraItens.Add(new Compras_Item(item.Value.Quantidade, item.Value.PrecoUnitario, item.Value.Id_Produto));
            }

            var usuarioId = User.Identity.GetUserId();

            var compra = new Compra(usuarioId, compraItens);
            /*salvando no banco*/
            _dal.Compra.Add(compra);
            _dal.SaveChanges();

            compra = _dal.Compra
               .Include(c => c.Itens)
               .Include(c => c.Usuario)
               .Include(c => c.Itens.Select(i => i.Produto))
               .FirstOrDefault(item => item.Id == compra.Id);


            return View(compra);
        }        
    }
}