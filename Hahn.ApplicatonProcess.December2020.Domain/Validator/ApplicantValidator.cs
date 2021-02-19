using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validator
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Name Must Be At Least 5 Characters");
            RuleFor(x => x.FamilyName).MinimumLength(5).WithMessage("FamilyName Must Be At Least 5 Characters");
            RuleFor(x => x.Address).MinimumLength(5).WithMessage("Address Must Be At Least 10 Characters");
            RuleFor(x => x.CountryOfOrigin).MustAsync(async (country, cancellation) => await CheckCountries(country)).WithMessage("Invalid Country Origion");
            RuleFor(x => x.EMailAddress).EmailAddress().WithMessage("Invalid Email");
            RuleFor(x => x.Age).InclusiveBetween(20, 60).WithMessage("Age Must Be Between 20 and 60");
            RuleFor(x => x.Hired).NotNull().WithMessage("Hired can not be null");

        }
        public async static Task<bool> CheckCountries(string country)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://restcountries.eu/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync($"rest/v2/name/{country}?fullText=true");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
