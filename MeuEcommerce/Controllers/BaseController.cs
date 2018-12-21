using MeuEcommerce.DAL;
using MeuEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuEcommerce.Controllers
{
    public class BaseController : Controller
    {
        static Categoria[] _categorias;

        protected ApplicationDbContext _dal = new ApplicationDbContext();

        protected Carrinho GetCarrinhoDaSessao()
        {
            if (Session["carrinho"] == null)
            {
                Session["carrinho"] = new Carrinho();
            }
            return (Carrinho)Session["carrinho"];
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Categorias = _dal.Categorias.ToArray();
            ViewBag.Carrinho = GetCarrinhoDaSessao();

            base.OnActionExecuting(filterContext);
        }
    }
}