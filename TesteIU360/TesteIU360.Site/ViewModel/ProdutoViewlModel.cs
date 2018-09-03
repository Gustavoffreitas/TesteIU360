using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteIU360.Site.ViewModel
{
	public class ProdutoViewlModel
	{
		public ProdutoViewlModel()
		{
			produtos = new List<TesteIU360.Model.Produto>();
		}

		public TesteIU360.Model.Produto produto { get; set; }

		public List<TesteIU360.Model.Produto> produtos { get; set; }
	}
}