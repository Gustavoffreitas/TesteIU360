using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteIU360.Model
{
    public class Vendedor
    {
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public bool Status { get; set; }
	}
}
