using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimonDente.Application;
using SimonDente.Domain;
using SimonDente.Infra.Data;
using SimonDente.AspNet.Models;

namespace SimonDente.AspNet.Controllers
{
    public class ConsultationController : Controller
    {
        private IConsultationRepository _repository;
        private IConsultationService _service;

        public ConsultationController()
        {
            _repository = new ConsultationRepository();
            _service = new ConsultationService(_repository);
        }
        // GET: Consultation
        public ActionResult Index()
        {
            try
            {
                List<Consultation> listConsultations = _service.GetAll();

                return View(listConsultations);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Consultation/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Consultation consultation = _service.Retrieve(id);

                return View(consultation);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: Consultation/Create
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

        // POST: Consultation/Create
        [HttpPost]
        public ActionResult Create(CreateViewModel createView)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                Consultation consultation = new Consultation();

                consultation.Name = createView.Name;
                consultation.Age = createView.Age;
                consultation.Cpf = createView.Cpf;
                consultation.Rg = createView.Rg;
                consultation.Type = createView.Type;
                consultation.Date = createView.Date;

                _service.Create(consultation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Consultation/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Consultation consultation = _service.Retrieve(id);

                return View(consultation);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateViewModel createView)
        {
            try
            {
                

                Consultation consultation = new Consultation();

                if (!ModelState.IsValid) return View();

                consultation.Id = id;
                consultation.Name = createView.Name;
                consultation.Age = createView.Age;
                consultation.Cpf = createView.Cpf;
                consultation.Rg = createView.Rg;
                consultation.Type = createView.Type;
                consultation.Date = createView.Date; 


                _service.Update(consultation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Consultation consultation = _service.Retrieve(id);

                return View(consultation);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // POST: Consultation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Consultation consultation = _service.Retrieve(id);

                _service.Delete(consultation.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
