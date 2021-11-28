using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Report.API.Controllers;
using Report.Application.Interfaces;
using Report.Domain.Dtos;
using Report.Domain.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Report.UnitTests
{
    public class ReportControllerTest
    {
        private readonly Mock<IReportService> _reportServiceMock;
        public ReportControllerTest()
        {
            _reportServiceMock = new Mock<IReportService>();
        }

        [Fact]
        public async Task GetReportAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _reportServiceMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(Response.Ok(new ReportDto { }, ""));

            var controller = CreateController();
            var result = await controller.GetReportAsync(Guid.Empty);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<ReportDto>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task GenerateReportAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _reportServiceMock.Setup(x => x.GenerateReportAsync(It.IsAny<string>())).ReturnsAsync(Response.Ok(Guid.Empty, ""));

            var controller = CreateController();
            var result = await controller.GenerateReportAsync("location");

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<Guid>>(((OkObjectResult)result).Value);
        }

        private ReportController CreateController()
        {
            var controller = new ReportController(_reportServiceMock.Object)
            {
                ControllerContext = { HttpContext = new Mock<HttpContext>().Object }
            };

            return controller;
        }

    }
}
