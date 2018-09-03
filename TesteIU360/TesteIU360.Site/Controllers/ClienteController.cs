using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteIU360.Site.ViewModel;

namespace TesteIU360.Site.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Form()
		{
			ClienteViewModel viewmodel = new ClienteViewModel();
			try
			{
				viewmodel.Vendedores = new TesteUI360.DataServices.VendedorDataServices().ListVendedor();
			}
			catch (Exception err)
			{

			}
			finally
			{

			}

			return View(viewmodel);

		}

		public ActionResult Edit(int ClienteId)
		{

			ClienteViewModel viewmodel = new ClienteViewModel();			
			try
			{
				viewmodel.Cliente = new TesteUI360.DataServices.ClienteDataServices().BuscaPorId(ClienteId);
				viewmodel.Vendedores = new TesteUI360.DataServices.VendedorDataServices().ListVendedor();
			}
			catch (Exception err)
			{

			}
			finally
			{

			}
			return View(viewmodel);
		}

		public ActionResult List()
		{
			ClienteViewModel viewmodel = new ClienteViewModel();
			TesteUI360.DataServices.ClienteDataServices cliente_srv = new TesteUI360.DataServices.ClienteDataServices();
			TesteUI360.DataServices.VendedorDataServices vendedores_srv = new TesteUI360.DataServices.VendedorDataServices();

			try
			{
				viewmodel.Vendedores = vendedores_srv.ListVendedor();
				viewmodel.Clientes = cliente_srv.ListCliente();
			}
			catch (Exception err)
			{

			}
			finally
			{
				cliente_srv = null;
			}
			return View(viewmodel);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AddNovoCliente(ClienteViewModel viewmodel)
		{
			try
			{
				viewmodel.Cliente.DataCadastro = DateTime.Today;
				if (new TesteUI360.DataServices.ClienteDataServices().Adicionar(viewmodel.Cliente))
					return Json(new { result = "Ok", msg = "Cliente cadastrado com sucesso", url = Url.Action("List", "Cliente") });
			}
			catch (Exception err)
			{

			}

			return Json(new { result = "Fail", msg = "Cliente não pode ser cadastrado" });
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AlterarCliente(ClienteViewModel viewmodel)
		{
			try
			{
				if (new TesteUI360.DataServices.ClienteDataServices().Alterar(viewmodel.Cliente))
					return Json(new { result = "Ok", msg = "Cliente atualizado com sucesso", url = Url.Action("List", "Cliente") });
			}
			catch (Exception err)
			{

			}
			return Json(new { result = "Fail", msg = "Cliente não pode ser atualizado" });
		}
	}
}