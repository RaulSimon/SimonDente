using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonDente.Application.CovenantApplication;
using SimonDente.Domain;
using SimonDente.Infra.Data.CovenantInfra;
using SimonDente.AspNet.Models;

namespace SimonDente.AspNet.Controllers
{
    public class CovenantController : Controller
    {
        private ICovenantRepository _repository;
        private ICovenantService _service;

        public CovenantController()
        {
            _repository = new CovenantRepository();
            _service = new CovenantService(_repository);
        }
        // GET: Covenant
        public ActionResult Index()
        {
            try
            {
                List<Covenant> listCovenants = _service.GetAll();

                return View(listCovenants);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Covenant/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Covenant covenant = _service.Retrieve(id);

                return View(covenant);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Covenant/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Covenant/Create
        [HttpPost]
        public ActionResult Create(CreateViewCovenantModel modelView)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                Covenant covenant = new Covenant();

                covenant.Name = modelView.Name;
                covenant.Business = modelView.Business;
                covenant.Plan = modelView.Plan;
                covenant.Coverage = modelView.Coverage;
                

                _service.Create(covenant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Covenant/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Covenant covenant = _service.Retrieve(id);

                return View(covenant);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Covenant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateViewCovenantModel modelView)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                Covenant covenant = new Covenant();

                covenant.Id = id;
                covenant.Name = modelView.Name;
                covenant.Business = modelView.Business;
                covenant.Plan = modelView.Plan;
                covenant.Coverage = modelView.Coverage;
                

                _service.Update(covenant);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Covenant/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Covenant covenant = _service.Retrieve(id);

                return View(covenant);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Covenant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Covenant covenant = _service.Retrieve(id);

                _service.Delete(covenant.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
