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
	public class ItemPedidoDataServices
	{
		public bool Adicionar(TesteIU360.Model.ItemPedido itemPedido)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.ItemPedido entity_itemPedido = new TesteIU360.Entity.ItemPedido();

				entity_itemPedido.IdPedido = itemPedido.IdPedido;
				entity_itemPedido.IdProduto = itemPedido.IdProduto;
				entity_itemPedido.Quantidade = itemPedido.Quantidade;

				try
				{
					dbContext.ItemPedido.Add(entity_itemPedido);
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

		public bool Alterar(TesteIU360.Model.ItemPedido itemPedido)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();

			try
			{
				dbContext = new TesteIU360Entities();
				TesteIU360.Entity.ItemPedido entity_itemPedido = new TesteIU360.Entity.ItemPedido();
				entity_itemPedido = dbContext.ItemPedido.Where(p => p.Id == itemPedido.Id).FirstOrDefault();

				entity_itemPedido.Id = itemPedido.Id;
				entity_itemPedido.IdPedido = itemPedido.IdPedido;
				entity_itemPedido.IdProduto = itemPedido.IdProduto;
				entity_itemPedido.Quantidade = itemPedido.Quantidade;

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

		public List<TesteIU360.Model.ItemPedido> ListItemPedido()
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				var entity_itemPedido = dbContext.ItemPedido.ToList();
				List<TesteIU360.Model.ItemPedido> listItemPedido = new List<TesteIU360.Model.ItemPedido>();

				foreach (TesteIU360.Entity.ItemPedido itemPedido in entity_itemPedido)
					listItemPedido.Add(Converters.DoReflection(itemPedido, new TesteIU360.Model.ItemPedido()));

				return listItemPedido;
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

		public TesteIU360.Model.ItemPedido BuscaPorId(int id)
		{
			TesteIU360Entities dbContext = new TesteIU360Entities();
			try
			{
				TesteIU360.Entity.ItemPedido entity_itemPedido = dbContext.ItemPedido.Where(p => p.Id == id).SingleOrDefault();
				TesteIU360.Model.ItemPedido itemPedido = Converters.DoReflection<TesteIU360.Entity.ItemPedido, TesteIU360.Model.ItemPedido>(entity_itemPedido, new TesteIU360.Model.ItemPedido());

				return itemPedido;

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
