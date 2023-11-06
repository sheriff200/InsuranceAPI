using AutoMapper;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using DataAccessLayer.Serilog;
using FluentAssertions;
using InfrastructureLayer.IServices;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Test.Services
{
    public class InsuranceServiceTest
    {

        private readonly Mock<IDBService> _mockDatabaseService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IHttpContextAccessor> _mockContextAccessor;
        private readonly Mock<IAuditService> _mockAuditService;
        private readonly Mock<ISerilogger> _mockSerilogger;
        private  InsuranceService _sut;


        public InsuranceServiceTest()
        {
            _mockDatabaseService = new();
            _mockMapper = new();
            _mockContextAccessor = new();
            _mockAuditService = new();
            _mockSerilogger = new();
        }


        [Fact]
        public async Task Service_PolicyHolderClaims_Should_Return_FailedAsync()
        {
            _sut = new InsuranceService(_mockDatabaseService.Object, _mockSerilogger.Object, _mockMapper.Object, _mockContextAccessor.Object, _mockAuditService.Object);
            
            var _imapperPolicyHolders = new PolicyHolders()
            {
                Id = 1,
                NationalIDNumber = 2,
                Name = "Sheriff",
                Surname = "Ebelebe",
                DateofBirth = DateTime.Now,
                PolicyNumber = "1234567",
                CreatedDate = DateTime.Now
            };
            _mockMapper.Setup(x => x.Map<PolicyHolders>(It.IsAny<PolicyHolderClaimRequest>())).Returns(_imapperPolicyHolders);

            var _iMapperClaims = new Claims()
            {
                Id = 1,
                NationalIDNumber = 2,
                ClaimID = 3,
                ExpenseAmount = 4,
                ExpenseDate = DateTime.Now,
                AppStage = 1,
                ClaimStatus = "Approved",
                NextStage = 1,
                Expenses = "Expenses",
                LastProcessor = "reviewer"
            };
            
            _mockDatabaseService.Setup(x => x.Add(It.IsAny<PolicyHolders>())).ReturnsAsync(0);

           var user = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new Claim[] { new Claim("MyClaim", "Approval") },
                            "Basic")
                        );

            _mockContextAccessor.Setup(x => x.HttpContext.User).Returns(user);

            var request = new PolicyHolderClaimRequest()
            {
                ClaimID = 1,
                DateofBirth = DateTime.Now,
                ExpenseDate = DateTime.Now,
                Surname = "Ebelebe",
                ExpenseAmount = 2000,
                Expenses = "Transportation",
                NationalIDNumber = 1,
                Name = "Sheriff",
                PolicyNumber = "1"
            };

            var result = await _sut.PolicyHolderClaims(request);

            result.Should().NotBeNull();

            result.ResponseCode.Should().Be("02");
            result.StatusCode.Should().Be("02");
            result.Should().BeOfType<WebApiResponse>();


        }



       

    }
}
