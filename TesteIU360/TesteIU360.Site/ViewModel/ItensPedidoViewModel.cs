using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteIU360.Site.ViewModel
{
	public class ItensPedidoViewModel
	{
		public ItensPedidoViewModel()
		{
			ItensPedidos = new List<Model.ItemPedido>();
			Pedidos = new List<Model.Pedido>();
			Produtos = new List<Model.Produto>();			
		}

		public Model.Pedido Pedido { get; set; }
		public List<Model.ItemPedido> ItensPedidos { get; set; }
		public List<Model.Pedido> Pedidos { get; set; }
		public List<Model.Produto> Produtos { get; set; }		
	}
}