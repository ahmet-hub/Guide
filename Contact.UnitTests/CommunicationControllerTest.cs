using Contact.API.Controllers;
using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Communication;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Contact.UnitTests
{
    public class CommunicationControllerTest
    {
        private readonly Mock<ICommunicationService> _communicationServiceMock;
        public CommunicationControllerTest()
        {
            _communicationServiceMock = new Mock<ICommunicationService>();
        }

        [Fact]
        public async Task CreateAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _communicationServiceMock.Setup(x => x.CreateAsync(It.IsAny<CommunicationCreateDto>())).ReturnsAsync(Response.Ok(new CommunicationDto { }, ""));

            var controller = CreateController();
            var result = await controller.PostAsync(new CommunicationCreateDto { });

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<CommunicationDto>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task DeleteAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _communicationServiceMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(Response.Ok(true, ""));

            var controller = CreateController();
            var result = await controller.DeleteAsync(Guid.Empty);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<bool>>(((OkObjectResult)result).Value);
        }

        private CommunicationController CreateController()
        {
            var controller = new CommunicationController(_communicationServiceMock.Object)
            {
                ControllerContext = { HttpContext = new Mock<HttpContext>().Object }
            };

            return controller;
        }

    }
}
