using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteIU360.Model
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }
		public string RazaoSocial { get; set; }
		public string Cnpj { get; set; }
		public string Telefone { get; set; }
		public DateTime DataCadastro { get; set; }
		public int IdVendedor { get; set; }
		public bool Status { get; set; }

		//public Vendedor Vendedor { get; set; }
	}
}
