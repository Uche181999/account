using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Account1.Controllers;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Account1.Test.Controllers
{
    public class HelloWorldControllerTests
    {
        private readonly HelloWorldController _controller ;
        public HelloWorldControllerTests()
        {
            _controller = new HelloWorldController(); //NullLogger<HelloWorldController>.Instance
        }

        [Fact]
        public void GetReturnHelloWorld()
        {
            var result = _controller.Get() as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal("hello world", result!.Value);
        }

        [Fact]
        public void GetReturnHelloWorldWithName()
        {
            var result = _controller.Get("uche") as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal("hello uche", result!.Value);
        }
    }
}