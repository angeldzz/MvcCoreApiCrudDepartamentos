using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDepartamentos.Models;
using MvcCoreApiCrudDepartamentos.Services;

namespace MvcCoreApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        private ServiceDepartamentos service;
        public DepartamentosController(ServiceDepartamentos service)
        {
            this.service = service;
        }
        public IActionResult Cliente()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.service.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.service.GetDepartamentoAsync(id);
            return View(departamento);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.service.CreateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Departamento departamento = await this.service.GetDepartamentoAsync(id);
            return View(departamento);
        }
         [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.service.UpdateDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteDepartamentoAsync(id);
            return RedirectToAction("Index");
        }
    }
}
