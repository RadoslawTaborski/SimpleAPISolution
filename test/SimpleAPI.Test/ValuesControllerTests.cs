using System;
using System.Linq;
using Moq;
using SimpleAPI.Controllers;
using Xunit;

namespace SimpleAPI.Test
{
    public class ValuesControllerTests 
    {
        ValuesController controller = new ValuesController();

        [Fact]
        public void Get_ReturnsMyNick()
        { 
            var returnValue = controller.Get(1);
            Assert.Equal("Radox", returnValue.Value);
        } 

        [Fact]
        public void GetActionResult_ReturnsDotnetAndAzure()
        {
            var returnValue = controller.GetActionResult();
            Assert.Equal(2, returnValue.Value.Count());
            Assert.Contains("dotnet", returnValue.Value); 
            Assert.Contains("azure", returnValue.Value);
        }

        [Fact]
        public void Post_ThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => controller.Post(It.IsAny<string>()));
        }
    }
}
