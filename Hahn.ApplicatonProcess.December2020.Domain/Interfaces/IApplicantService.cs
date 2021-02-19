using Hahn.ApplicatonProcess.December2020.Data;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        List<Applicant> GetList();
        Applicant GetById(int id);
        void Add(Applicant applicant);
        void Update(int id, Applicant applicant);
        void Delete(int id);
    }
}
