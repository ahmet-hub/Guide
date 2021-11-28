using Contact.API.Controllers;
using Contact.Application.Interfaces;
using Contact.Domain.Dtos.Communication;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Contact.UnitTests
{
    public class ContactControllerTest
    {
        private readonly Mock<IContactService> _contactServiceMock;
        public ContactControllerTest()
        {
            _contactServiceMock = new Mock<IContactService>();
        }

        [Fact]
        public async Task GetAllAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(Response.Ok(new List<ContactDto>() { new ContactDto { } }, ""));

            var controller = CreateController();
            var result = await controller.GetAllAsync();

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<List<ContactDto>>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task GetAllAsyncDetail_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.GetAllWithDetailAsync()).ReturnsAsync(Response.Ok(new List<ContactDetailDto>() { new ContactDetailDto { CommunicationDtos = new List<CommunicationDto>() { new CommunicationDto { } } } }, ""));

            var controller = CreateController();
            var result = await controller.GetAllDetails();

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<List<ContactDetailDto>>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task GetAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {

            _contactServiceMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(Response.Ok(new ContactDto { }, ""));


            var controller = CreateController();
            var result = await controller.GetAsync(Guid.Empty);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<ContactDto>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task GetAsyncDetail_RetrunsStatus200Ok_WhenValidRequestProvided()
        {

            _contactServiceMock.Setup(x => x.GetDetailAsync(It.IsAny<Guid>())).ReturnsAsync(Response.Ok(new ContactDetailDto { CommunicationDtos = new List<CommunicationDto>() { new CommunicationDto { } } }, ""));

            var controller = CreateController();
            var result = await controller.GetWithDetailAsync(Guid.Empty);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<ContactDetailDto>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task CreateAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.CreateAsync(It.IsAny<ContactCreateDto>())).ReturnsAsync(Response.Ok(new ContactDto { }, ""));

            var controller = CreateController();
            var result = await controller.PostAsync(new ContactCreateDto { });

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<ContactDto>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task UpdateAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.UpdateAsync(It.IsAny<ContactUpdateDto>())).ReturnsAsync(Response.Ok(true, ""));

            var controller = CreateController();
            var result = await controller.PutAsync(new ContactUpdateDto { });

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<bool>>(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task DeleteAsync_RetrunsStatus200Ok_WhenValidRequestProvided()
        {
            _contactServiceMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(Response.Ok(true, ""));

            var controller = CreateController();
            var result = await controller.DeleteAsync(Guid.Empty);

            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, ((OkObjectResult)result).StatusCode);
            Assert.IsType<Response<bool>>(((OkObjectResult)result).Value);
        }

        private ContactController CreateController()
        {
            var controller = new ContactController(_contactServiceMock.Object)
            {
                ControllerContext = { HttpContext = new Mock<HttpContext>().Object }
            };

            return controller;
        }

    }
}
