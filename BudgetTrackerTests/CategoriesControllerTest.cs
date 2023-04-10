using BudgetTracker.Controllers;
using BudgetTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace BudgetTrackerTests
{
    [TestClass]
    public class CategoriesControllerTest
    {
        private ApplicationDbContext _context;
        private CategoriesController controller;

        private DbContextOptions<ApplicationDbContext> _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        [TestInitialize]
        public void TestInitialize()
        {
            //mock database
            _context = new ApplicationDbContext(_dbContextOptions);

            _context.Category.Add(new BudgetTracker.Models.Category
            {
                
            });

            

            controller = new CategoriesController(null);
        }
        [TestMethod]
        public async void IndexLoadView()
        {
            var result = (ViewResult)await controller.Details(1);
            Assert.IsNotNull(result);
        }
    }
}