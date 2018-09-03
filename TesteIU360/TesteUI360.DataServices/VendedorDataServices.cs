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
	public class VendedorDataServices
	{
		public bool Adicionar(TesteIU360.Model.Vendedor vendedor)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Vendedor entity_vendedor = new TesteIU360.Entity.Vendedor();
								
				entity_vendedor.Nome = vendedor.Nome;
				entity_vendedor.Email = vendedor.Email;
				entity_vendedor.Ativo = vendedor.Status;

				try
				{
					dbContext.Vendedor.Add(entity_vendedor);
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

		public bool Alterar(TesteIU360.Model.Vendedor vendedor)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Vendedor entity_vendedor = new TesteIU360.Entity.Vendedor();
				entity_vendedor = dbContext.Vendedor.Where(p => p.Id == vendedor.Id).FirstOrDefault();

				entity_vendedor.Id = vendedor.Id;
				entity_vendedor.Nome = vendedor.Nome;
				entity_vendedor.Email = vendedor.Email;
				entity_vendedor.Ativo = vendedor.Status;
									
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

		public List<TesteIU360.Model.Vendedor> ListVendedor()
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				var entityVendedor = dbContext.Vendedor.ToList();
				List<TesteIU360.Model.Vendedor> listVendedor = new List<TesteIU360.Model.Vendedor>();

				foreach (TesteIU360.Entity.Vendedor vendedor in entityVendedor)
					listVendedor.Add(Converters.DoReflection(vendedor, new TesteIU360.Model.Vendedor()));

				return listVendedor;
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

		public TesteIU360.Model.Vendedor BuscaPorId(int id)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				TesteIU360.Entity.Vendedor entityVendedor = dbContext.Vendedor.Where(p => p.Id == id).SingleOrDefault();
				TesteIU360.Model.Vendedor vendedor = Converters.DoReflection<TesteIU360.Entity.Vendedor, TesteIU360.Model.Vendedor>(entityVendedor, new TesteIU360.Model.Vendedor());

				return vendedor;

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
