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
    public class ClienteDataServices
    {
		public bool Adicionar(TesteIU360.Model.Cliente cliente)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Cliente entity_cliente = new TesteIU360.Entity.Cliente();

				entity_cliente.RazaoSocial = cliente.RazaoSocial;
				entity_cliente.CNPJ = cliente.Cnpj;
				entity_cliente.DataCadastro = cliente.DataCadastro;
				entity_cliente.Telefone = cliente.Telefone;
				entity_cliente.IdVendedor = cliente.IdVendedor;
				entity_cliente.Ativo = cliente.Status;

				try
				{
					dbContext.Cliente.Add(entity_cliente);
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

		public bool Alterar(TesteIU360.Model.Cliente cliente)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Cliente entity_cliente = new TesteIU360.Entity.Cliente();
				entity_cliente = dbContext.Cliente.Where(p => p.Id == cliente.Id).FirstOrDefault();

				entity_cliente.Id = cliente.Id;
				entity_cliente.RazaoSocial = entity_cliente.RazaoSocial;
				entity_cliente.CNPJ = cliente.Cnpj;
				entity_cliente.Telefone = cliente.Telefone;
				entity_cliente.DataCadastro = DateTime.Now.Date;
				entity_cliente.IdVendedor = cliente.IdVendedor;
				entity_cliente.Ativo = cliente.Status;

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

		public List<TesteIU360.Model.Cliente> ListCliente()
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				var entity_cliente = dbContext.Cliente.ToList();
				List<TesteIU360.Model.Cliente> listCliente = new List<TesteIU360.Model.Cliente>();

				foreach (TesteIU360.Entity.Cliente cliente in entity_cliente)
					listCliente.Add(Converters.DoReflection(cliente, new TesteIU360.Model.Cliente()));

				return listCliente;
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

		public TesteIU360.Model.Cliente BuscaPorId(int id)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				TesteIU360.Entity.Cliente entity_cliente = dbContext.Cliente.Where(p => p.Id == id).SingleOrDefault();
				TesteIU360.Model.Cliente cliente = Converters.DoReflection<TesteIU360.Entity.Cliente, TesteIU360.Model.Cliente>(entity_cliente, new TesteIU360.Model.Cliente());

				return cliente;

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
