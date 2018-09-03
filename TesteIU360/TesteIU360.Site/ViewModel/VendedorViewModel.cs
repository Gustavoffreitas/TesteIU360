using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteIU360.Site.ViewModel
{
	public class VendedorViewModel
	{
		public VendedorViewModel()
		{
			vendedores = new List<TesteIU360.Model.Vendedor>();
		}

		public TesteIU360.Model.Vendedor vendedor { get; set; }

		public List<TesteIU360.Model.Vendedor> vendedores { get; set; }
	}
}