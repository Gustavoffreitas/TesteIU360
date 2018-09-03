using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteIU360.Site.ViewModel;

namespace TesteIU360.Site.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Form()
		{
			ProdutoViewlModel viewmodel = new ProdutoViewlModel();
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

		public ActionResult Edit(int ProdutoId)
		{

			ProdutoViewlModel viewmodel = new ProdutoViewlModel();

			try
			{
				viewmodel.produto = new TesteUI360.DataServices.ProdutoDataServices().BuscaPorId(ProdutoId);
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
			ProdutoViewlModel viewmodel = new ProdutoViewlModel();
			TesteUI360.DataServices.ProdutoDataServices produto_srv = new TesteUI360.DataServices.ProdutoDataServices();

			try
			{
				viewmodel.produtos = produto_srv.ListProduto();
			}
			catch (Exception err)
			{

			}
			finally
			{
				produto_srv = null;
			}
			return View(viewmodel);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AddNovoProduto(ProdutoViewlModel viewmodel)
		{
			try
			{

				if (new TesteUI360.DataServices.ProdutoDataServices().Adicionar(viewmodel.produto))
					return Json(new { result = "Ok", msg = "Produto cadastrado com sucesso", url = Url.Action("List", "Produto") });
			}
			catch (Exception err)
			{

			}

			return Json(new { result = "Fail", msg = "Produto não pode ser cadastrado" });
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public JsonResult AlterarProduto(ProdutoViewlModel viewmodel)
		{
			try
			{
				if (new TesteUI360.DataServices.ProdutoDataServices().Alterar(viewmodel.produto))
					return Json(new { result = "Ok", msg = "Produto atualizado com sucesso", url = Url.Action("List", "Produto") });
			}
			catch (Exception err)
			{

			}
			return Json(new { result = "Fail", msg = "Produto não pode ser atualizado" });
		}
	}
}