using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteIU360.Model;
using TesteIU360.Entity;
using System.Data.Entity.Validation;

namespace TesteUI360.DataServices
{
	public class ProdutoDataServices
	{
		public bool Adicionar(TesteIU360.Model.Produto produto)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Produto entity_produto = new TesteIU360.Entity.Produto();

				entity_produto.Nome = produto.Nome;
				entity_produto.Preco = produto.Preco;
				entity_produto.Ativo = produto.Status;

				try
				{
					dbContext.Produto.Add(entity_produto);
					dbContext.SaveChanges();
				}
				catch (DbEntityValidationException e)
				{
					return false;
				}
				return true;
			}
			catch (Exception err)
			{
				return false;
			}
			finally
			{
				dbContext.Dispose();
			}
		}

		public bool Alterar(TesteIU360.Model.Produto produto)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Produto entity_produto = new TesteIU360.Entity.Produto();
				entity_produto = dbContext.Produto.Where(p => p.Id == produto.Id).FirstOrDefault();

				entity_produto.Id = produto.Id;
				entity_produto.Nome = produto.Nome;
				entity_produto.Preco = produto.Preco;
				entity_produto.Ativo = produto.Status;

				dbContext.SaveChanges();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				dbContext.Dispose();
			}
		}

		public List<TesteIU360.Model.Produto> ListProduto()
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				var entity_produto = dbContext.Produto.ToList();
				List<TesteIU360.Model.Produto> listProduto = new List<TesteIU360.Model.Produto>();

				foreach (TesteIU360.Entity.Produto produto in entity_produto)
					listProduto.Add(Converters.DoReflection(produto, new TesteIU360.Model.Produto()));

				return listProduto;
			}
			catch (Exception err)
			{
				throw err;
			}
			finally
			{
				dbContext.Dispose();
			}
		}

		public TesteIU360.Model.Produto BuscaPorId(int id)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				TesteIU360.Entity.Produto entity_produto = dbContext.Produto.Where(p => p.Id == id).SingleOrDefault();
				TesteIU360.Model.Produto produto = Converters.DoReflection<TesteIU360.Entity.Produto, TesteIU360.Model.Produto>(entity_produto, new TesteIU360.Model.Produto());

				return produto;

			}
			catch (Exception err)
			{
				throw err;
			}
			finally
			{
				dbContext.Dispose();
			}
		}
	}
}
