using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using FluentAssertions;
using InfrastructureLayer.IServices;
using Insurance.Test.MockData;
using InsuranceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Test.Controllers
{
    public class AccountControllerTest
    {

        private readonly AccountController _sut;
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly MockDataClass _mockLoginRequest = new();

        public AccountControllerTest()
        {
            _mockAccountService = new();
            _sut = new(_mockAccountService.Object);
        }


        [Fact]
        public async Task Login_Should_Return_BadRequest()
        {
            var response = new WebApiResponse()
            {
                StatusCode = "400",
            };

            var req = new ValidateUserRequest()
            {
                Username = "jxasmail@example.com",
                Password = "XDR56789JKSsss%",
                Role = "Approval"
            };

            var _req = _mockLoginRequest.GenerateLoginRequestObject();
            _mockAccountService.Setup(x => x.ValidateUserLogin(req)).ReturnsAsync(response);

            var result = await _sut.Login(req);

            result.Should().BeOfType<ObjectResult>();

            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(400);

            var value = (WebApiResponse?)objectResult.Value;

            value.Should().NotBeNull();
            value.Should().BeEquivalentTo(response, x => x.ComparingByMembers<WebApiResponse>());
            value.Should().BeOfType<WebApiResponse>();

            value?.StatusCode.Should().Be("400");
        }


        [Fact]
        public async Task Login_Should_Return_Internal_Server_Error()
        {
            var response = new WebApiResponse()
            {
                StatusCode = "500",
            };

            var req = new ValidateUserRequest()
            {
                Username = "jxasmail@example.com",
                Password = "XDR56789JKSsss%",
                Role = "Approval"
            };

            var _req = _mockLoginRequest.GenerateLoginRequestObject();
            _mockAccountService.Setup(x => x.ValidateUserLogin(req)).ReturnsAsync(response);

            var result = await _sut.Login(req);

            result.Should().BeOfType<ObjectResult>();

            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(500);

            var value = (WebApiResponse?)objectResult.Value;

            value.Should().NotBeNull();
            value.Should().BeOfType<WebApiResponse>();
            value?.StatusCode.Should().Be("500");
        }


        [Fact]
        public async Task Login_Should_Return_Successful()
        {
            var response = new WebApiResponse()
            {
                StatusCode = "200",
                ResponseCode = "00"
            };

            var req = new ValidateUserRequest()
            {
                Username = "mail@example.com",
                Password = "XDR56789JKSsss%",
                Role = "Approval"
            };

            var _req = _mockLoginRequest.GenerateLoginRequestObject();
            _mockAccountService.Setup(x => x.ValidateUserLogin(req)).ReturnsAsync(response);

            var result = await _sut.Login(req);

            result.Should().BeOfType<ObjectResult>();

            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(200);

            var value = (WebApiResponse?)objectResult.Value;

            value.Should().NotBeNull();
            value.Should().BeOfType<WebApiResponse>();
            value?.StatusCode.Should().Be("200");
            value?.ResponseCode.Should().Be("00");
        }

    }
}
