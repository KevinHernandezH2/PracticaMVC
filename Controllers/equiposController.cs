using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Models;
using mvcPractica01.Models;

namespace PracticaMVC.Controllers
{
    public class equiposController : Controller
    {

        private readonly equiposDbContext _equiposDbContext;

        public equiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }
        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas,"id_marcas", "nombre_marca");

            var listaDeTipos= (from t in _equiposDbContext.tipo_equipo
                                 select t).ToList();
            ViewData["listadoDeTipos"] = new SelectList(listaDeTipos, "id_tipo_equipo", "descripcion");

            var listaDeEstados = (from e in _equiposDbContext.estados_equipo
                                 select e).ToList();
            ViewData["listadoDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");


            var listadoDeEquipos = (from e in _equiposDbContext.equipos
                                  join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                  select new
                                  {
                                      nombre = e.nombre,
                                      descripcion = e.descripcion,
                                      marca_id = e.marca_id,
                                      marca_nombre = m.nombre_marca,
                                  }).ToList();


            ViewData["listadoEquipos"] = listadoDeEquipos;

            return View();

        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
