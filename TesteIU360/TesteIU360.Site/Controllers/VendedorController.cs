using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteIU360.Site.ViewModel;

namespace TesteIU360.Site.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Form()
		{
			VendedorViewModel viewmodel = new VendedorViewModel();
			try
			{
			
			}
			catch (Exception err)
			{
				
			}
			finally
			{

			}

			return View(viewmodel);

		}

		public ActionResult Edit(int VendedorId)
		{

			VendedorViewModel viewmodel = new VendedorViewModel();

			try
			{
				viewmodel.vendedor = new TesteUI360.DataServices.VendedorDataServices().BuscaPorId(VendedorId);				
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
			VendedorViewModel viewmodel = new VendedorViewModel();
			TesteUI360.DataServices.VendedorDataServices vendedor_srv = new TesteUI360.DataServices.VendedorDataServices();

			try
			{
				viewmodel.vendedores = vendedor_srv.ListVendedor();
			}
			catch (Exception err)
			{
				
			}
			finally
			{
				vendedor_srv = null;
			}
			return View(viewmodel);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AddNovoVendedor(VendedorViewModel viewmodel)
		{
			try
			{
				if (new TesteUI360.DataServices.VendedorDataServices().Adicionar(viewmodel.vendedor))
					return Json(new { result = "Ok", msg = "Vendedor cadastrado com sucesso", url = Url.Action("List", "Vendedor") });
			}
			catch (Exception err)
			{
				
			}

			return Json(new { result = "Fail", msg = "Vendedor não pode ser cadastrado" });
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AlterarVendedor(VendedorViewModel viewmodel)
		{
			try
			{
				if (new TesteUI360.DataServices.VendedorDataServices().Alterar(viewmodel.vendedor))
					return Json(new { result = "Ok", msg = "Vendedor atualizado com sucesso", url = Url.Action("List", "Vendedor") });
			}
			catch (Exception err)
			{
				
			}
			return Json(new { result = "Fail", msg = "Vendedor não pode ser atualizado" });
		}
	}
}