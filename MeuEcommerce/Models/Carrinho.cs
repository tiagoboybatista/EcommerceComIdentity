using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Carrinho
    {
        public Dictionary<int, CarrinhoItem> Itens;

        public Carrinho()
        {
            Itens = new Dictionary<int, CarrinhoItem>();
        }

        public void AddProduto(Produto produto)
        {
            /*verificar se já existe um item igual no meu carrinho*/
            if (Itens.ContainsKey(produto.Id))
            {
                Itens[produto.Id].Quantidade++;
            }
            else
            {
                var carrinhoItem = new CarrinhoItem(produto.Id, produto.Nome, produto.Descricao, produto.Preco);

                Itens.Add(produto.Id, carrinhoItem);
            }
        }


        public int TotalItensCarrinho()
        {
            int total = 0;
            foreach (var item in Itens)
            {
                total = total + item.Value.Quantidade; /*para ler o dicionário (o item > chave > valor da coisa)*/
            }
            return total;
        }        

        public decimal GetPrecoTotal()
        {
            decimal resultado = 0;
            foreach (var item in Itens.Values)
            {
                resultado += item.PrecoTotal;
            }
            return resultado;
        }
    }

}