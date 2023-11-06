using InfrastructureLayer.IServices;
using InsuranceAPI.Controllers;
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

        public AccountControllerTest()
        {
            _mockAccountService = new();
            _sut = new(_mockAccountService.Object);
        }


        [Fact]
        public void Login_Should_Return_BadRequest()
        {

        }

    }
}
