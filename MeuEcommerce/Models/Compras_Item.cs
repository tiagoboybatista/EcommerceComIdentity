using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Compras_Item
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public decimal PrecoUnitario { get; set; }  
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public Compras_Item() { }

        public Compras_Item(int quantidade, decimal precoUnitario, int produtoId)
        {
            this.Qtd = quantidade;
            this.PrecoUnitario = precoUnitario;
            this.ProdutoId = produtoId;
        }
    }
}