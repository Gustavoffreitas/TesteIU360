using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteIU360.Model;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void add()
		{
			Vendedor vendedor = new Vendedor();

			vendedor.Nome = "teste8";
			vendedor.Email = "teste@teste8";
			vendedor.Status = true;


			TesteUI360.DataServices.VendedorDataServices dataService = new TesteUI360.DataServices.VendedorDataServices();
			dataService.Adicionar(vendedor);
		}

		[TestMethod]
		public void update()
		{
			Vendedor vendedor = new Vendedor();

			vendedor.Id = 1;
			vendedor.Nome = "teste1234";
			vendedor.Email = "teste@testewerr2";
			vendedor.Status = true;


			TesteUI360.DataServices.VendedorDataServices dataService = new TesteUI360.DataServices.VendedorDataServices();
			dataService.Alterar(vendedor);
		}

		[TestMethod]
		public void GetAll()
		{
			TesteUI360.DataServices.VendedorDataServices dataService = new TesteUI360.DataServices.VendedorDataServices();
			var result = dataService.ListVendedor();
		}
	}
}
