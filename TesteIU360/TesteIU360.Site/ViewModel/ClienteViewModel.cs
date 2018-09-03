using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteIU360.Site.ViewModel
{
	public class ClienteViewModel
	{
		public ClienteViewModel()
		{
			Clientes = new List<Model.Cliente>();
			Vendedores = new List<Model.Vendedor>();
		}

		public Model.Cliente Cliente { get; set; }

		public List<Model.Cliente> Clientes { get; set; }

		public List<Model.Vendedor> Vendedores { get; set; }
	}
}