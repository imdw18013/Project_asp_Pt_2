using CompanyApp.Entities;
using CompanyApp.Interface;
using CompanyApp.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly IDapperHelper _dapperHelper;

        public CollegeService(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }
        public List<College> GetCompanies()
        {
            var data = _dapperHelper.GetAll<College>("Select * from College", null, commandType: CommandType.Text);
            return data.ToList();
        }

        public College GetCompanyByID(int ID)
        {
            var data = _dapperHelper.Get<College>("Select * from College where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public College InsertCompany(College model)
        {
            var data = _dapperHelper.Insert<College>("Insert into College(CollegeName,[Email],[PhoneNo],[Address],[StartDate]) values" +
                " ('" + model.CollegeName + "','" + model.Email + "','" + model.PhoneNo + "','" + model.Address + "','" + Convert.ToDateTime(model.StartDate).ToString("MM/dd/yyyy") + "')", null, commandType: CommandType.Text);
            return data;
        }

        public College UpdateCompany(College model)
        {
            var data = _dapperHelper.Update<College>("Update College set CollegeName ='" + model.CollegeName + "',[Email]='" + model.Email + "',[PhoneNo]='" + model.PhoneNo + "'," +
                "[Address]='" + model.Address + "',[StartDate]='" + Convert.ToDateTime(model.StartDate).ToString("MM/dd/yyyy")  + "' where ID ='" + model.ID + "'", null, commandType: CommandType.Text);
            return data;
        }

        public int DeleteCompany(int ID)
        {
            var data = _dapperHelper.Execute("Delete College where ID ='" + ID + "'", null, commandType: CommandType.Text);
            return data;
        }

    }
}
