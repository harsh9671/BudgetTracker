using BudgetTracker.Controllers;
using BudgetTracker.Data;
using BudgetTracker.Models;
using Microsoft.AspNetCore.Components.Forms;
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

            _context.Category.AddRange(new List <Category>
            {
                new Category {Id = 1, Name = "Medical & Healthcare" },
                new Category {Id = 2, Name = "Utilities"},
                new Category {Id = 3 ,Name = "Insurance" }
            });
        }

        [TestMethod]
        public async Task Delete_GivenValidCategoryId()
        {
            // Arrange
            var categorytIdToDelete = 1;

            // Act
            var result = _controller.Delete(categorytIdToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            var project = await _context.Category.FindAsync(categorytIdToDelete);
            Assert.IsNull(project);
        }

        [TestMethod]
        public async Task Delete_GivenInvalidCategoryId()
        {
            // Arrange
            var projectIdToDelete = 4;

            // Act
            await _controller.Delete(projectIdToDelete);

            // Assert
            Assert.AreEqual(3, _context.Category.Count());
        }

        [TestMethod]
        public void Delete_RemovesCategoryFromDatabase()
        {
            // Arrange
            var categorytIdToDelete = 1;

            // Act
            _controller.Delete(categorytIdToDelete);

            // Assert
            Assert.AreEqual(2, _context.Category.Count());
            Assert.IsFalse(_context.Category.Any(p => p.Id == categorytIdToDelete));
        }

  
    }
}