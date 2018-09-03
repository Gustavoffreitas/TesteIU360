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
	public class PedidoDataServices
	{
		public bool Adicionar(TesteIU360.Model.Pedido pedido)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Pedido entity_pedido = new TesteIU360.Entity.Pedido();

				entity_pedido.IdCliente = pedido.IdCliente;
				entity_pedido.IdVendedor = pedido.IdVendedor;				
				entity_pedido.ValorTotal = pedido.ValorTotal;

				try
				{
					dbContext.Pedido.Add(entity_pedido);
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

		public bool Alterar(TesteIU360.Model.Pedido pedido)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.Pedido entity_pedido = new TesteIU360.Entity.Pedido();
				entity_pedido = dbContext.Pedido.Where(p => p.Id == pedido.Id).FirstOrDefault();

				entity_pedido.Id = pedido.Id;
				entity_pedido.IdCliente = pedido.IdCliente;
				entity_pedido.IdVendedor = pedido.IdVendedor;
				entity_pedido.ValorTotal = pedido.ValorTotal;

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

		public List<TesteIU360.Model.Pedido> ListPedido()
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				var entity_pedido = dbContext.Pedido.ToList();
				List<TesteIU360.Model.Pedido> listPedido = new List<TesteIU360.Model.Pedido>();

				foreach (TesteIU360.Entity.Pedido pedido in entity_pedido)
					listPedido.Add(Converters.DoReflection(pedido, new TesteIU360.Model.Pedido()));

				return listPedido;
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

		public TesteIU360.Model.Pedido BuscaPorId(int id)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				TesteIU360.Entity.Pedido entity_pedido = dbContext.Pedido.Where(p => p.Id == id).SingleOrDefault();
				TesteIU360.Model.Pedido pedido = Converters.DoReflection<TesteIU360.Entity.Pedido, TesteIU360.Model.Pedido>(entity_pedido, new TesteIU360.Model.Pedido());

				return pedido;

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
