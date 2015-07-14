using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Better.Application.Interface;
using Better.Domain.Entities;
using Better.MVC.ViewModels;

namespace Better.MVC.Controllers
{
    public class EstacionamentosController : Controller
    {
        //mudar para nao ter contato com a infra

        private readonly IEstacionamentoAppService _estacionamentoApp;
        private readonly ITabelaValorAppService _tabelaValorApp;

        public EstacionamentosController(IEstacionamentoAppService estacionamentoApp , ITabelaValorAppService tabelaValorApp)
        {
            _estacionamentoApp = estacionamentoApp;
            _tabelaValorApp = tabelaValorApp;
        }

        public ActionResult Index()
        {
            var estacionamentoModel = Mapper.Map<IEnumerable<Estacionamento>, IEnumerable<EstacionamentoViewModel>>(_estacionamentoApp.GetAll());

            foreach (var item in estacionamentoModel)
            {
                var estacionamentoDomain = Mapper.Map<EstacionamentoViewModel, Estacionamento>(item);

                item.TotalPagar = _estacionamentoApp.GetTotal(estacionamentoDomain);
            }
            
            return View(estacionamentoModel);
        }


        // GET: Estacionamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estacionamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstacionamentoViewModel estacionamento)
        {
            if (ModelState.IsValid)
            {
                var estacionamentoDomain = Mapper.Map<EstacionamentoViewModel, Estacionamento>(estacionamento);
                var tabelaModel = _tabelaValorApp.BuscarPorData();
                estacionamentoDomain.TabelaValorId = tabelaModel.TabelaValorId;
                estacionamentoDomain.DataEntrada = DateTime.Now;
                _estacionamentoApp.Add(estacionamentoDomain);

                return RedirectToAction("Index");
            }
            return View(estacionamento);
        }

        // GET: Estacionamentos/Edit/5
        public ActionResult Edit(int id)
        {
            EstacionamentoViewModel e = Mapper.Map<Estacionamento, EstacionamentoViewModel>(_estacionamentoApp.GetById(id));
            return View(e);
        }
        // POST: Estacionamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var estacionamentoDomain = _estacionamentoApp.GetById(id);

                estacionamentoDomain.DataSaida = DateTime.Now;

                _estacionamentoApp.Update(estacionamentoDomain);
                 return RedirectToAction("Index");

        }

        // GET: Estacionamentos/Delete/5
    }
}
