using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteIU360.Site.ViewModel;

namespace TesteIU360.Site.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Form()
		{
			PedidoViewModel viewmodel = new PedidoViewModel();
			try
			{
				viewmodel.Pedidos = new TesteUI360.DataServices.PedidoDataServices().ListPedido();
				viewmodel.Vendedores = new TesteUI360.DataServices.VendedorDataServices().ListVendedor();
				viewmodel.Clientes = new TesteUI360.DataServices.ClienteDataServices().ListCliente();
			}
			catch (Exception err)
			{

			}
			finally
			{

			}

			return View(viewmodel);
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AddNovoPedido(PedidoViewModel viewmodel)
		{
			try
			{				
				if (new TesteUI360.DataServices.PedidoDataServices().Adicionar(viewmodel.Pedido))
					return Json(new { result = "Ok", msg = "Pedido cadastrado com sucesso", url = Url.Action("List", "Pedido") });
			}
			catch (Exception err)
			{

			}

			return Json(new { result = "Fail", msg = "Pedido não pode ser cadastrado" });
		}

	}
}