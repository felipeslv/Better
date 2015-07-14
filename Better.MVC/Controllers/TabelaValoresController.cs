using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Better.Application.Interface;
using Better.Domain.Entities;
using Better.MVC.ViewModels;

namespace Better.MVC.Controllers
{
    public class TabelaValoresController : Controller
    {
        private readonly ITabelaValorAppService _tabelaValorApp;

        public TabelaValoresController(ITabelaValorAppService tabelaValorApp)
        {
            _tabelaValorApp = tabelaValorApp;
        }

        // GET: TabelaValores
        public ActionResult Index()
        {
            var tabelaModel = Mapper.Map<IEnumerable<TabelaValor>, IEnumerable<TabelaValorViewModel>>(_tabelaValorApp.GetAll());

            return View(tabelaModel.Last());
        }
        [HttpPost]
        public ActionResult Index(TabelaValorViewModel tabela)
        {
            if (ModelState.IsValid)
            {
                var tabelaValorDomain = Mapper.Map<TabelaValorViewModel, TabelaValor>(tabela);
                _tabelaValorApp.Add(tabelaValorDomain);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
