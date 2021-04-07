using CompanyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.IServices
{
    public interface ICollegeService
    {
        List<College> GetCompanies();
        College InsertCompany(College model);
        College GetCompanyByID(int ID);
        College UpdateCompany(College model);
        int DeleteCompany(int ID);
    }
}
