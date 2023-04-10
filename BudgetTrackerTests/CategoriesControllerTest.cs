using BudgetTracker.Controllers;
using BudgetTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BudgetTrackerTests
{
    [TestClass]
    public class CategoriesControllerTest
    {
        private ApplicationDbContext _context;
        private CategoriesController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            _context= new ApplicationDbContext(dbOptions);

            _context.Category.AddRange(new List <BudgetTracker.Models.Category>
            {
                new BudgetTracker.Models.Category {Id = 1, Name = "Harsh Patel" },
                new BudgetTracker.Models.Category {Id = 2, Name = "Dhruv Patel"},
                new BudgetTracker.Models.Category {Id = 3 ,Name = "Rishi Patel"}

            });
        }
        [TestMethod]
        public async void IndexLoadsView()
        {
            var result =(ViewResult) await _controller.Index();
            Assert.IsNotNull(result);
        }
    }
}