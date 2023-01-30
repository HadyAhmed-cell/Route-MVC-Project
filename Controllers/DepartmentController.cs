using Microsoft.AspNetCore.Mvc;
using Route.NetBLL.Interfaces;
using Route.NetDAL.Entities;

namespace Route.NetPL.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _repository.Get(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _repository.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(department);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, Department department)
        {

            await _repository.Delete(department);
            return RedirectToAction("Index");
        }


    }
}
