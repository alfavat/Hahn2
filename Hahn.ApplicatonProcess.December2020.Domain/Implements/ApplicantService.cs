using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Hahn.ApplicatonProcess.December2020.Domain.Implements
{
    public class ApplicantService : IApplicantService
    {
        public void Add(Applicant applicant)
        {
            applicant.ID = AppDbContext.applicants.Select(f => f.ID).DefaultIfEmpty(0).Max() + 1;

            AppDbContext.applicants.Add(applicant);
        }

        public void Delete(int id)
        {
            var applicant = AppDbContext.applicants.FirstOrDefault(f => f.ID == id);
            if (applicant != null)
                AppDbContext.applicants.Remove(applicant);
        }

        public Applicant GetById(int id) => AppDbContext.applicants.FirstOrDefault(f => f.ID == id);

        public List<Applicant> GetList() => AppDbContext.applicants;

        public void Update(int id, Applicant applicant)
        {
            var oldApplicant = AppDbContext.applicants.FirstOrDefault(f => f.ID == id);
            // we could use update for all props but in this senario I used the old way(remove/add)
            if (oldApplicant != null)
            {
                AppDbContext.applicants.Remove(oldApplicant);
            }
            applicant.ID = id;
            AppDbContext.applicants.Add(applicant);
        }
    }
}
