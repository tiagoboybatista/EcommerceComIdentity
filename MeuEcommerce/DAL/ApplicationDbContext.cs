using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MeuEcommerce.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeuEcommerce.DAL
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<Categoria> Categorias { get; set; }

        public IDbSet<Compra> Compra { get; set; }
        public IDbSet<Compras_Item> Compras_Item { get; set; }

    }
}