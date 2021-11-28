using Contact.API.Controllers;
using Contact.Application.Interfaces;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Contact.UnitTests
{
    public class ReportControllerTest
    {
        private readonly Mock<IContactService> _contactServiceMock;
        public ReportControllerTest()
        {
            _contactServiceMock = new Mock<IContactService>();
        }

        [Fact]
        public async Task GetReportAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.GetLocationReportAsync(It.IsAny<string>())).ReturnsAsync(Response.Ok(new Report { }, ""));

            var controller = CreateController();
            var result = await controller.GetReportAsync("Location");

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<Report>>(((OkObjectResult)result).Value);
        }

        private ReportController CreateController()
        {
            var controller = new ReportController(_contactServiceMock.Object)
            {
                ControllerContext = { HttpContext = new Mock<HttpContext>().Object }
            };

            return controller;
        }

    }
}
