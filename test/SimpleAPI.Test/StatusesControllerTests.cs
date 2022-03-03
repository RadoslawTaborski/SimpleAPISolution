using System;
using System.Linq;
using Moq;
using SimpleAPI.Controllers;
using SimpleAPI.Repositories;
using Xunit;

namespace SimpleAPI.Test;

public class StatusesControllerTests
{

    [Fact]
    public void Get_ReturnsMyNick()
    {
        var repository = new Mock<StatusRepository>();
        var controller = new StatusesController(repository.Object);
        var returnValue = controller.Get(1);
        Assert.Equal("Radox", returnValue.Value);
    }

    [Fact]
    public void GetActionResult_ReturnsDotnetAndAzure()
    {
        var repository = new Mock<StatusRepository>();
        var controller = new StatusesController(repository.Object);
        var returnValue = controller.GetActionResult();
        Assert.Equal(2, returnValue.Value.Count());
        Assert.Contains("dotnet", returnValue.Value);
        Assert.Contains("azure", returnValue.Value);
    }

    [Fact]
    public void Post_ThrowNotImplementedException()
    {
        var repository = new Mock<StatusRepository>();
        var controller = new StatusesController(repository.Object);
        Assert.Throws<NotImplementedException>(() => controller.Post(It.IsAny<string>()));
    }
}