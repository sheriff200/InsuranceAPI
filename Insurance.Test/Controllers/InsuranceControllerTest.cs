﻿using DataAccessLayer.Model.Dto.Request;
using DataAccessLayer.Model.Dto.Response;
using FluentAssertions;
using InfrastructureLayer.IServices;
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
   
    public class InsuranceControllerTest
    {
        private readonly InsuranceController _sut;
        private readonly Mock<IInsuranceService> _mockinsuranceservice;

        public InsuranceControllerTest()
        {
            _mockinsuranceservice = new();
            _sut = new(_mockinsuranceservice.Object);
        }

        [Fact]
        public async void PolicyHolderClaims_Should_Return_ExpectationFailed()
        {
            //Arrange
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

            var response = new WebApiResponse()
            {
                StatusCode = "02",

            };
            //Assign
            _mockinsuranceservice.Setup(x => x.PolicyHolderClaims(request)).ReturnsAsync(response);
            var result = await _sut.PolicyHolderClaims(request);

            result.Should().BeOfType<ObjectResult>();

            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(417);

            var value = (WebApiResponse?)objectResult.Value;

            value.Should().NotBeNull();
            value.Should().BeEquivalentTo(response, x => x.ComparingByMembers<WebApiResponse>());
            value.Should().BeOfType<WebApiResponse>();

            value?.StatusCode.Should().Be("02");
        }


        [Fact]
        public async void PolicyHolderClaims_Should_Return_InternalServerError()
        {
            //Arrange
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

            var response = new WebApiResponse()
            {
                StatusCode = "500",

            };
            //Assign
            _mockinsuranceservice.Setup(x => x.PolicyHolderClaims(request)).ReturnsAsync(response);
            var result = await _sut.PolicyHolderClaims(request);

            result.Should().BeOfType<ObjectResult>();

            var objectResult = (ObjectResult)result;
            objectResult.StatusCode.Should().Be(500);

            var value = (WebApiResponse?)objectResult.Value;

            value.Should().NotBeNull();
            value.Should().BeEquivalentTo(response, x => x.ComparingByMembers<WebApiResponse>());
            value.Should().BeOfType<WebApiResponse>();

            value?.StatusCode.Should().Be("500");
        }


    }
}