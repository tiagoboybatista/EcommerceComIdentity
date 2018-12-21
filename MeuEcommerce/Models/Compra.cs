using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEcommerce.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public CompraStatus Status { get; set; }

        public virtual List<Compras_Item> Itens { get; set; }

        public string UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [NotMapped]/*para não salvar no banco*/
        public decimal PrecoTotal
           => Itens.Sum(i => i.PrecoUnitario*i.Qtd);

        public Compra() { }

        public Compra (string usuarioId, List<Compras_Item> itens)
        {
            Data = DateTime.Now;
            Status = CompraStatus.AgPagamento;
            Itens = itens;
            UsuarioId = usuarioId;
        }
    }

    public enum CompraStatus
    {
        AgPagamento = 1,
        SeparandoPedido = 2,
        EntregueTransportadore = 3,
        Finalizado = 4
    
    }
}