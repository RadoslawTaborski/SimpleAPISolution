using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog.Core;
using SimpleAPI.Controllers;
using SimpleAPI.Repositories;
using Xunit;

namespace SimpleAPI.Test;

public class StatusesControllerTests
{
    [Fact]
    public async void Get_Element1_ReturnsTestsStatus()
    {
        var repository = new Mock<IStatusRepository>();
        Models.Status value = new() { Id=1, Name="test"};
        repository.Setup(m=>m.Get(It.IsAny<int>())).ReturnsAsync(value);
        var logger = new Mock<Serilog.ILogger>();
        var controller = new StatusesController(logger.Object, repository.Object);
        var returnValue = await controller.Get(1);
        var okObjectResult = returnValue.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);
        var model = okObjectResult.Value as Models.Status;
        Assert.NotNull(model);
        Assert.Equal(1, model.Id);
        Assert.Equal("test", model.Name);
    }
}