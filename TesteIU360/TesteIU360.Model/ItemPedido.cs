using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteIU360.Model
{
	public class ItemPedido
	{
		[Key]
		public int Id { get; set; }
		public int IdPedido { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }

		public Pedido Pedido { get; set; }
		public Produto Produto { get; set; }
	}
}
