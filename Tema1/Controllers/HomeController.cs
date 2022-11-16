using Aspose.Words;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Tema1.Context;
using Tema1.Models;
using Tema1.VModels;

namespace Tema1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Tema1EgovContext _context;

        public HomeController(ILogger<HomeController> logger, Tema1EgovContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var teatre = _context.Teatru
                    .Select(t => new DropDownItem() { Value = t.TeatruId, Name = t.Nume })
                    .ToList();

            var piese = _context.Piesa
                    .Where(p => p.TeatruId == teatre.First().Value)
                    .Select(t => new DropDownItem() { Value = t.PiesaId, Name = t.Nume })
                    .ToList();

            var orare = _context.Orar
                    .Where(p => p.PiesaId == piese.First().Value)
                    .Select(t => new DropDownItem() { Value = t.OrarId, Name = t.DataOra.ToString() })
                    .ToList();

            var pret = _context.Orar
                    .FirstOrDefault(p => p.PiesaId == piese.First().Value)?.Pret ?? 0;

            var vmModelRezervare = new RezervarVm()
            {
                Teatre = teatre,
                Piese = piese,
                Orare = orare,
                PretFinal = pret,
                PretInitial = pret,
            };

            return View(vmModelRezervare);
        }

        [HttpPost]
        public IActionResult Index(RezervarVm model)
        {
            if (!ModelState.IsValid)
            {
                var teatre = _context.Teatru
                        .Select(t => new DropDownItem() { Value = t.TeatruId, Name = t.Nume })
                        .ToList();

                var piese = _context.Piesa
                        .Where(p => p.TeatruId == model.TeatruAles)
                        .Select(t => new DropDownItem() { Value = t.PiesaId, Name = t.Nume })
                        .ToList();

                var orare = _context.Orar
                        .Where(p => p.PiesaId == model.PiesaAleasa)
                        .Select(t => new DropDownItem() { Value = t.OrarId, Name = t.DataOra.ToString() })
                        .ToList();

                model.Teatre = teatre;
                model.Piese = piese;
                model.Orare = orare;
                return View(model);
            }

            var rezervare = new Rezervare
            {
                RezervareId = Guid.NewGuid(),
                OrarId = model.OrarAles,
                Email = model.Email,
                Nume = model.Nume,
                Prenume = model.Prenume,
                Student = model.Student,
                Pensionar = model.Pensionar,
            };


            var orar = _context.Orar.FirstOrDefault(o => o.OrarId == model.OrarAles);
            var piesa = _context.Piesa.FirstOrDefault(p => p.PiesaId == model.PiesaAleasa);
            var teatru = _context.Teatru.FirstOrDefault(p => p.TeatruId == model.TeatruAles);



            _context.Rezervare.Add(rezervare);

            _context.SaveChanges();
            return DownloadRezervare(rezervare, orar, piesa, teatru, model.PretFinal);
        }

        public ActionResult DownloadRezervare(Rezervare r, Orar o, Piesa p, Teatru t, double pret)
        {
            Document doc = new Document("../Tema1/Controllers/RezervareTemplate.docx");
            doc.Range.Replace("<RezervareId>", r.RezervareId.ToString());
            doc.Range.Replace("<Nume>", r.Nume);
            doc.Range.Replace("<Prenume>", r.Prenume);
            doc.Range.Replace("<Email>", r.Email);
            doc.Range.Replace("<pret>", pret.ToString());
            doc.Range.Replace("<Data>", o.DataOra.ToString());
            doc.Range.Replace("<Teatru>", t.Nume);
            doc.Range.Replace("<Piesa>", p.Nume);

            doc.Save("../Tema1/Controllers/Rezervare.docx", SaveFormat.Docx);

            byte[] fileBytes = System.IO.File.ReadAllBytes("../Tema1/Controllers/Rezervare.docx");

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Rezervare.docx");

        }

        public List<DropDownItem> PieseDeTeatru(Guid teatruId)
        {
            var piese = _context.Piesa
                .Where(p => p.TeatruId == teatruId)
                .Select(t => new DropDownItem() { Value = t.PiesaId, Name = t.Nume })
                .ToList();

            return piese;
        }
        public List<DropDownItem> OrarePiese(Guid piesaId)
        {
            var orare = _context.Orar
                .Where(p => p.PiesaId == piesaId)
                .Select(t => new DropDownItem() { Value = t.OrarId, Name = t.DataOra.ToString() })
                .ToList();

            return orare;
        }
        public double Pret(Guid orarId)
        {
            return _context.Orar
                .SingleOrDefault(p => p.OrarId == orarId)?.Pret ?? 0;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult XmlDownload()
        {
            var xmlDocument = new XmlDocument();

            var rezervariElement = xmlDocument.CreateElement("Rezervari");

            var rezervariList = _context.Rezervare.ToList();
            foreach (var rezervare in rezervariList)
            {
                var orar = _context.Orar
                    .FirstOrDefault(o => o.OrarId == rezervare.OrarId);
                var piesa = _context.Piesa
                    .FirstOrDefault(p => p.PiesaId == orar.PiesaId);
                var teatru = _context.Teatru
                    .FirstOrDefault(p => p.TeatruId == piesa.TeatruId);
                var pret = orar.Pret;
                if (rezervare.Student != null)
                {
                    pret = pret * ((bool)rezervare.Student ? 0.75 : 1);
                }
                else if (rezervare.Pensionar != null)
                {
                    pret = pret * ((bool)rezervare.Pensionar ? 0.5 : 1);
                }

                var rezervareElement = xmlDocument.CreateElement("Rezervare");
                rezervareElement.AppendChild(xmlDocument.CreateElement("RezervareId", rezervare.RezervareId.ToString()));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Nume", rezervare.Nume));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Prenume", rezervare.Prenume));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Email", rezervare.Email));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Student", rezervare.Student.ToString()));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Pensionar", rezervare.Pensionar.ToString()));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Teatru", teatru.Nume));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Piesa", piesa.Nume));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Data", orar.DataOra.ToString()));
                rezervareElement.AppendChild(xmlDocument.CreateElement("Pret", pret.ToString()));

                rezervariElement.AppendChild(rezervareElement);
            }
           

            xmlDocument.AppendChild(rezervariElement);

            xmlDocument.Save("../Tema1/Controllers/Rezervari.xml");
        
            byte[] fileBytes = System.IO.File.ReadAllBytes("../Tema1/Controllers/Rezervari.xml");

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Rezervari.xml");
        }
    }
}

