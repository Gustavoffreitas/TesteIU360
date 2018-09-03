using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteIU360.Site.ViewModel
{
	public class PedidoViewModel
	{
		public PedidoViewModel()
		{
			Pedidos = new List<Model.Pedido>();
			Vendedores = new List<Model.Vendedor>();
			Clientes = new List<Model.Cliente>();
		}

		public Model.Pedido Pedido { get; set; }

		public List<Model.Pedido> Pedidos { get; set; }

		public List<Model.Vendedor> Vendedores { get; set; }

		public List<Model.Cliente> Clientes { get; set; }
	}
}