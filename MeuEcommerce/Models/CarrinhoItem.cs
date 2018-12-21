using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class CarrinhoItem
    {
        public int Id_Produto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public CarrinhoItem(int id_produto, string nome, string descricao, decimal precoUnitario)
        {
            Id_Produto = id_produto;
            Nome = nome;
            Descricao = descricao;
            Quantidade = 1;
            PrecoUnitario = precoUnitario;
        }



        public decimal PrecoTotal
            => PrecoUnitario * Quantidade;
    }
}