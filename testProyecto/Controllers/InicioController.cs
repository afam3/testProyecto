using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testProyecto.Datos;
using testProyecto.Models;

namespace testProyecto.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;
        
        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        //metodo "Index"
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Correo.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Correo correo)
        {
            if (ModelState.IsValid)
            {

                //agregar la fecha y hora actual
                //correo.FechaCreacion = DateTime.Now; //no se tiene el campo FechaCreacion en la BD

                _contexto.Correo.Add(correo);
                await _contexto.SaveChangesAsync(); //aqui se guarda en la bd
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = _contexto.Correo.Find(id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Correo correo)
        {
            if (ModelState.IsValid)
            {

                _contexto.Update(correo);
                await _contexto.SaveChangesAsync(); //aqui se guarda en la bd
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = _contexto.Correo.Find(id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var correo = _contexto.Correo.Find(id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarCorreo(int? id)
        {
            var correo = await _contexto.Correo.FindAsync(id);
            if (correo == null)
            {
                return View();
            }
            //borrado
            _contexto.Correo.Remove(correo);
            await _contexto.SaveChangesAsync();//aqui se borra fisicamente en la bd
            return RedirectToAction(nameof(Index));

         }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Archivo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
