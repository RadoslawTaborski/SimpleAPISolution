using System;
using System.Linq;
using SimpleAPI.Controllers;
using Xunit;

namespace SimpleAPI.Test
{
    public class ValuesControllerTests 
    {
        ValuesController controller = new ValuesController();

        [Fact]
        public void Get_ReturnsMyName()
        {
            var returnValue = controller.Get(1);
            Assert.Equal("Radox", returnValue.Value); //TODO: 
        } 

        [Fact]
        public void GetActionResult_ReturnsDotnetAndAzure()
        {
            var returnValue = controller.GetActionResult();
            Assert.Equal(2, returnValue.Value.Count());
            Assert.Contains("dotnet", returnValue.Value); 
            Assert.Contains("azure", returnValue.Value);
        }
    }
}
