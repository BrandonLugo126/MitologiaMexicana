using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitologiaMexicana.Models.entitys;
using MitologiaMexicana.Models.ViewModels;

namespace MitologiaMexicana.Controllers
{
    public class HomeController : Controller
    {
        MitologiaMexicanaContext context = new MitologiaMexicanaContext();

        public IActionResult Index()
        {
            var todas = context.Civilizaciones
                .Select(c => new CivilizacionModel
                {
                    Id = c.IdCivilizacion,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion ?? ""
                })
                .ToList();

            var random = new Random();
            var vm = todas
                .OrderBy(c => random.Next())
                .Take(3)
                .ToList();

            return View(vm);
        }
        public IActionResult Civilizaciones()
        {
            
            var vm = context.Civilizaciones
                .Select(c => new CivilizacionesViewModels
                {
                    Nombre = c.Nombre,
                    Periodo = (c.PeriodoInicio<0 ? $"{c.PeriodoInicio}a.C " : $"{c.PeriodoInicio}d.C " ) + " - " +
                    (c.PeriodoFin < 0 ? $"{c.PeriodoFin}a.C " : $"{c.PeriodoFin}d.C "),
                    Region = c.Region,
                    Capital = c.Capital,
                    Lengua = c.Lengua,
                    Descripcion = c.Descripcion
                })
                .ToList();

            return View(vm);
        }

        public IActionResult Dioses(string? id) 
        {          
            
            DiosesViewModel vm = new();
            if (id != null)
            {
                vm = context.Civilizaciones.Include(x => x.CivilizacionDios).Where(x => x.Nombre == id).Select(x => new DiosesViewModel
                {
                    Civilizacion = x.Nombre,                   
                    civilizaciones = context.Civilizaciones.Select(y => y.Nombre).ToList(),
                    Dioses = x.CivilizacionDios.Select(cd => new DiosModel
                    {
                        Id = cd.IdDiosNavigation.Id,
                        NombreGeneral = cd.NombreLocal,
                        Civilizacion = cd.IdCivilizacionNavigation.Nombre,
                        Descripcion = cd.IdDiosNavigation.Descripcion,
                        Dominio = cd.IdDiosNavigation.Dominio,
                        Genero = cd.IdDiosNavigation.Genero

                    }).ToList()
                }).First();
            }
            else {
                vm = context.Civilizaciones.Include(x => x.CivilizacionDios).Select(x => new DiosesViewModel
                {
                    Civilizacion = x.Nombre,                   
                    civilizaciones = context.Civilizaciones.Select(y => y.Nombre).ToList(),
                    Dioses = x.CivilizacionDios.Select(cd => new DiosModel
                    { 
                        Id= cd.IdDiosNavigation.Id,
                        NombreGeneral = cd.NombreLocal,
                        Civilizacion = cd.IdCivilizacionNavigation.Nombre,
                        Descripcion = cd.IdDiosNavigation.Descripcion,
                        Dominio = cd.IdDiosNavigation.Dominio,
                        Genero = cd.IdDiosNavigation.Genero
                    }).ToList()
                }).First();
            }

            return View(vm);
        }
    }
}
