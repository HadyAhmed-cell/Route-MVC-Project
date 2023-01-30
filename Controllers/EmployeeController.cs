using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Route.NetBLL.Interfaces;
using Route.NetDAL.Entities;
using Route.NetPL.Helper;
using Route.NetPL.Models;

namespace Route.NetPL.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment environment;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.environment = environment;
        }

        public async Task<IActionResult> Index(string SearchValue = "")
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var employees = await _unitOfWork.EmployeeRepository.GetAll();
                var mappedEmployee = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployee);
            }
            else
            {
                var employees = await _unitOfWork.EmployeeRepository.Search(SearchValue);
                var mappedEmployee = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployee);

            }


        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var emp = await _unitOfWork.EmployeeRepository.Get(id);



            if (emp == null)
            {
                return NotFound();
            }

            var mappedemp = _mapper.Map<Employee>(emp);

            return View(mappedemp);

        }
        public async Task<IActionResult> Create()
        {
            //ViewData["Message"] = "Hello";

            //ViewBag.Message = "Hello";

            ViewBag.Departments = await _unitOfWork.EmployeeRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            //var mappedEmployee = new Employee()
            //{
            //    Id = Employee.Id,
            //    Name = Employee.Name,
            //    Address = Employee.Address,
            //    DepartmentId = Employee.DepartmentId,
            //    Email = Employee.Email,
            //    HireDate = Employee.HireDate,
            //    Salary = Employee.Salary,
            //    PhoneNumber = Employee.PhoneNumber,
            //    IsActive = Employee.IsActive,
            //};
            if (ModelState.IsValid)
            {
                employee.ImgName = DocumentSettings.UploadFile(employee.Image, "imgs");
                var mappedEmployee = _mapper.Map<Employee>(employee);
                await _unitOfWork.EmployeeRepository.Create(mappedEmployee);

                employee.CreationDate = DateTime.Now;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = await _unitOfWork.EmployeeRepository.GetAll();
                return View(employee);
            }

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.EmployeeRepository.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            var mappedEmployee = _mapper.Map<EmployeeViewModel>(employee);
            ViewBag.Departments = await _unitOfWork.EmployeeRepository.GetAll();
            return View(mappedEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, EmployeeViewModel employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<Employee>(employee);

                    await _unitOfWork.EmployeeRepository.Update(mappedEmp);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return View(employee);
                }
            }

            ViewBag.Departments = await _unitOfWork.EmployeeRepository.GetAll();
            return View(employee);
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _unitOfWork.EmployeeRepository.Get(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    var mappedemp = _mapper.Map<EmployeeViewModel>(employee);

        //    return View(mappedemp);


        //}

        public async Task<IActionResult> Delete(int? id)
        {


            var emp = await _unitOfWork.EmployeeRepository.Get(id);

            var mappedEmp = _mapper.Map<Employee>(emp);

            string imgPath = environment.WebRootPath + "\\files\\imgs\\" + emp.ImgName;

            if (System.IO.File.Exists(imgPath))
            {
                System.IO.File.Delete(imgPath);
            }

            else
            {
                return NotFound();
            }

            await _unitOfWork.EmployeeRepository.Delete(mappedEmp);

            return RedirectToAction(nameof(Index));
        }

    }
}
