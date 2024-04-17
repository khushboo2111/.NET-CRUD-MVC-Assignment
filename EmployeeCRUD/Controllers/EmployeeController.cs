using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;        
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            Employee employee = new Employee
            {
                Name = addEmployeeViewModel.Name,
                Department = addEmployeeViewModel.Department,
                Project = addEmployeeViewModel.Project,
                Age = addEmployeeViewModel.Age,
            };

            await dbContext.employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Employee");

        }

        public async Task<IActionResult> List()
        {
            var employees = await dbContext.employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.employees.FindAsync(viewModel.Id);
            if (employee is not null)
            {
                employee.Name = viewModel.Name;
                employee.Department = viewModel.Department;
                employee.Project = viewModel.Project;
                employee.Age = viewModel.Age;

                await dbContext.SaveChangesAsync();
            }       
            return RedirectToAction("List", "Employee");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var employee = await dbContext.employees.FindAsync(viewModel.Id);
            if (employee is not null)
            {
                dbContext.employees.Remove(employee);
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", "Employee");
        }
    }
}
