using Hahn.ApplicatonProcess.December2020.Data;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Web.Examples
{
    internal class ApplicantRequestExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant
            {
                Address = "Main st , Istanbul , Turkey",
                Age = 25,
                CountryOfOrigin = "Turkey",
                EMailAddress = "test@test.com",
                FamilyName = "Last Name",
                Hired = false,
                Name = "First Name"
            };
        }
    }
    internal class ApplicantResponseExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant
            {
                Address = "Main st , Ankara , Turkey",
                Age = 45,
                CountryOfOrigin = "Turkey",
                EMailAddress = "test@test.com",
                FamilyName = "L Name",
                Hired = false,
                ID = 1,
                Name = "F Name"
            };
        }
    }

    internal class ApplicantsResponseExample : IExamplesProvider<List<Applicant>>
    {
        public List<Applicant> GetExamples()
        {
            return new List<Applicant> {
                    new Applicant
                    {
                        Address = "Main st , Istanbul , Turkey",
                        Age = 50,
                        CountryOfOrigin = "Turkey",
                        EMailAddress = "test@test.com",
                        FamilyName = "Last Name",
                        Hired = false,
                        ID = 1,
                        Name = "First Name"
                    } };
        }
    }
}
