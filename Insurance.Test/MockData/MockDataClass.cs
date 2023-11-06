using Bogus;
using DataAccessLayer.Model.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Test.MockData
{
    public class MockDataClass
    {

        public List<ValidateUserRequest> GenerateLoginRequestObject()
        {
            var req = new Faker<ValidateUserRequest>()
                .RuleFor(x => x.Username, x => x.Person.Email)
                .RuleFor(x => x.Password, x => x.Random.AlphaNumeric(10))
                .RuleFor(x => x.Role, x => x.Name.JobTitle());

            return req.Generate(1);
        }
    }
}
