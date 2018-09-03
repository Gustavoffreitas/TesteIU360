using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteIU360.Model
{
	public class Pedido
	{
		[Key]
		public int Id { get; set; }
		public int IdCliente { get; set; }
		public int IdVendedor { get; set; }
		public decimal ValorTotal { get; set; }

		public Cliente Cliente { get; set; }
		public Cliente Vendedor { get; set; }
	}
}
