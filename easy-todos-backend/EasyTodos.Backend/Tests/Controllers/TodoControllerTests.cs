using backend.Controllers;
using backend.Database;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace backend.Tests.Controllers;

[TestFixture]
public class TodoControllerTests
{
    private readonly User _testUser = new User
    {
        Id = 1,
        Username = "TEST"
    };
    
    [Test]
    public void CreateTodo_ValidTodo()
    {
        var mockSet = new Mock<DbSet<Todo>>();

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();

        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var result = sut.Create(new NewTodo("TEST DESCRIPTION", _testUser));
        var createdAtActionResult = result as CreatedAtActionResult;
        
        Assert.IsNotNull(createdAtActionResult);
        Assert.AreEqual(201, createdAtActionResult?.StatusCode);

        var todo = createdAtActionResult?.Value as Todo;
        Assert.AreEqual("TEST DESCRIPTION", todo?.Description);
        Assert.AreEqual("TEST", todo?.CreateUser.Username);
        
        mockSet.Verify(m => m.Add(It.IsAny<Todo>()), Times.Once);
        mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }
    
    [Test]
    public void Get_ReturnsAllTodos()
    {
        var data = new List<Todo>
        {
            new() { Description = "BBB" },
            new() { Description = "ZZZ" },
            new() { Description = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Todo>>();
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();
        
        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var okObjectResult = sut.GetAll() as OkObjectResult;
        
        Assert.IsNotNull(okObjectResult);
        Assert.AreEqual(200, okObjectResult?.StatusCode);

        var results = okObjectResult?.Value as List<Todo>;
        Assert.IsNotNull(results);
        Assert.AreEqual(3, results?.Count);
        Assert.AreEqual("BBB", results?[0].Description);
        Assert.AreEqual("ZZZ", results?[1].Description);
        Assert.AreEqual("AAA", results?[2].Description);
    }
    
    [Test]
    public void GetById_ExistsAndReturnsTodo()
    {
        var data = new List<Todo>
        {
            new() { Id = 1, Description = "BBB" },
            new() { Id = 2, Description = "ZZZ" },
            new() { Id = 3, Description = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Todo>>();
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();
        
        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var okObjectResult = sut.Get(2) as OkObjectResult;
        
        Assert.IsNotNull(okObjectResult);
        Assert.AreEqual(200, okObjectResult?.StatusCode);

        var result = okObjectResult?.Value as Todo;
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result?.Id);
        Assert.AreEqual("ZZZ", result?.Description);
    }
    
    [Test]
    public void GetById_DoesNotExistAndReturns404()
    {
        var data = new List<Todo>
        {
            new() { Id = 1, Description = "BBB" },
            new() { Id = 2, Description = "ZZZ" },
            new() { Id = 3, Description = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Todo>>();
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();
        
        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var notFoundObjectResult = sut.Get(5) as NotFoundResult;
        
        Assert.IsNotNull(notFoundObjectResult);
        Assert.AreEqual(404, notFoundObjectResult?.StatusCode);
    }
    
    [Test]
    public void DeleteById_ExistsAndReturnsTodo()
    {
        var data = new List<Todo>
        {
            new() { Id = 1, Description = "BBB" },
            new() { Id = 2, Description = "ZZZ" },
            new() { Id = 3, Description = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Todo>>();
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();
        
        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var result = sut.Delete(2) as OkResult;
        
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }
    
    [Test]
    public void DeleteById_DoesNotExistAndReturns404()
    {
        var data = new List<Todo>
        {
            new() { Id = 1, Description = "BBB" },
            new() { Id = 2, Description = "ZZZ" },
            new() { Id = 3, Description = "AAA" },
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Todo>>();
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Todo>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<DatabaseContext>();
        mockContext.Setup(m => m.Todos).Returns(mockSet.Object);
        
        var mockLogger = new Mock<ILogger<TodosController>>();
        
        var sut = new TodosController(mockLogger.Object, mockContext.Object);
        var notFoundObjectResult = sut.Delete(5) as NotFoundResult;
        
        Assert.IsNotNull(notFoundObjectResult);
        Assert.AreEqual(404, notFoundObjectResult?.StatusCode);
    }
}