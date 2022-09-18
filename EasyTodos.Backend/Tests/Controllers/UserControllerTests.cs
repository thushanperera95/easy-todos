using backend.Controllers;
using backend.Database.Contexts;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace backend.Tests.Controllers;

[TestFixture]
public class UserControllerTests
{
    [Test]
    public void CreateUser_ValidUser()
    {
        var mockSet = new Mock<DbSet<User>>();

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<UsersController>>();

        var sut = new UsersController(mockLogger.Object, mockContext.Object);
        var result = sut.CreateUser(new NewUser("TEST USERNAME", "TEST PASSWORD", "TEST FIRST", "TEST LAST", "TEST@TEST.COM"));
        var createdAtActionResult = result as CreatedAtActionResult;
        
        Assert.IsNotNull(createdAtActionResult);
        Assert.AreEqual(201, createdAtActionResult?.StatusCode);

        var user = createdAtActionResult?.Value as User;
        Assert.AreEqual("TEST USERNAME", user?.Username);
        Assert.AreEqual("TEST FIRST", user?.FirstName);
        Assert.AreEqual("TEST LAST", user?.LastName);
        Assert.AreEqual("TEST@TEST.COM", user?.Email);
        Assert.AreNotEqual("TEST PASSWORD", user?.Hash);
        
        mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once);
        mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void Get_ReturnsAllUsers()
    {
        var data = new List<User>
        {
            new() { FirstName = "BBB" },
            new() { FirstName = "ZZZ" },
            new() { FirstName = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<UsersController>>();
        
        var sut = new UsersController(mockLogger.Object, mockContext.Object);
        var okObjectResult = sut.Get() as OkObjectResult;
        
        Assert.IsNotNull(okObjectResult);
        Assert.AreEqual(200, okObjectResult?.StatusCode);

        var results = okObjectResult?.Value as List<User>;
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results?.Count);
        Assert.AreEqual("BBB", results?[0].FirstName);
        Assert.AreEqual("ZZZ", results?[1].FirstName);
        Assert.AreEqual("AAA", results?[2].FirstName);
    }
    
    [Test]
    public void GetById_ExistsAndReturnsUser()
    {
        var data = new List<User>
        {
            new() { Id = 1, FirstName = "BBB" },
            new() { Id = 2, FirstName = "ZZZ" },
            new() { Id = 3, FirstName = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<UsersController>>();
        
        var sut = new UsersController(mockLogger.Object, mockContext.Object);
        var okObjectResult = sut.GetById(2) as OkObjectResult;
        
        Assert.IsNotNull(okObjectResult);
        Assert.AreEqual(200, okObjectResult?.StatusCode);

        var result = okObjectResult?.Value as User;
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result?.Id);
        Assert.AreEqual("ZZZ", result?.FirstName);
    }
    
    [Test]
    public void GetById_DoesNotExistAndReturns404()
    {
        var data = new List<User>
        {
            new() { Id = 1, FirstName = "BBB" },
            new() { Id = 2, FirstName = "ZZZ" },
            new() { Id = 3, FirstName = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<UsersController>>();
        
        var sut = new UsersController(mockLogger.Object, mockContext.Object);
        var notFoundObjectResult = sut.GetById(5) as NotFoundResult;
        
        Assert.IsNotNull(notFoundObjectResult);
        Assert.AreEqual(404, notFoundObjectResult?.StatusCode);
    }
}