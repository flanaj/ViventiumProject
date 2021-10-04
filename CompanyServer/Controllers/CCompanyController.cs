using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyServer.Controllers
{
	/// <summary>
	/// Summary description for CCompanyController
	/// </summary>
	[ApiController]
	public class CCompanyController : ControllerBase
	{
		[HttpPost]
		[Route("DataStore")]
		public void DataStore()
		{
			string data = null;
			using (StreamReader rdr = new StreamReader(Request.Body))
			{
				Task<string> readTask = rdr.ReadToEndAsync();
				readTask.Wait();

				data = readTask.Result;
			}

			if (data == null) throw new ArgumentNullException("Specify Data.");
			// check for valid CSV format left out for brevity

			using (DBObjectModel.CCompanyContext context = new DBObjectModel.CCompanyContext())
			{
				context.Employees.RemoveRange(context.Employees);
				context.Companies.RemoveRange(context.Companies);

				context.SaveChanges();               

				foreach (Dictionary<string, string> row in SUtils.ParseCSVData(data))
				{
					int companyId = 0;
					if (!int.TryParse(row["CompanyId"], out companyId)) 
						continue;

					int employeeId = 0;
					if (!int.TryParse(row["EmployeeId"], out employeeId)) 
						continue;

					DateTime hireDate;
					if (!DateTime.TryParse(row["EmployeeHireDate"], out hireDate)) 
						continue;

					DBObjectModel.CCompany company = null;
					if ((company = context.Companies.Find(companyId)) == null)
					{
						company = new DBObjectModel.CCompany
						{
							Id = companyId,
							Code = row["CompanyCode"],
							Description = row["CompanyDescription"]
						};
						context.Companies.Add(company);
					}

					DBObjectModel.CEmployee employee = null;
					if ((employee = context.Employees.Find(employeeId)) == null)
					{
						employee = new DBObjectModel.CEmployee
						{
							Id = employeeId,
							CompanyId = companyId,
							Company = company,
							FirstName = row["EmployeeFirstName"],
							LastName = row["EmployeeLastName"],
							Email = row["EmployeeEmail"],
							Department = row["EmployeeDepartment"],
							HireDate = hireDate
						};
						context.Employees.Add(employee);
					}

					company.Employees.Add(employee);
				}

				context.SaveChanges();
			}
		}

		[HttpGet]
		[Route("Companies")]
		public IEnumerable<DataTransferObjectModel.CCompanyHeader> Companies()
        {
			List<DataTransferObjectModel.CCompanyHeader> RetVal = new List<DataTransferObjectModel.CCompanyHeader>();
			using (DBObjectModel.CCompanyContext context = new DBObjectModel.CCompanyContext())
            {
				foreach (DBObjectModel.CCompany company in context.Companies.Include(c => c.Employees))
                {
					// implicit casting
					RetVal.Add(company);
                }
            }
			return RetVal;
        }

		[HttpGet]
		[Route("Companies/{id}")]
		public DataTransferObjectModel.CCompany Companies(int id)
		{
			List<DataTransferObjectModel.CCompanyHeader> RetVal = new List<DataTransferObjectModel.CCompanyHeader>();
			using (DBObjectModel.CCompanyContext context = new DBObjectModel.CCompanyContext())
			{
				if (context.Companies.Where(c => c.Id == id).Count() > 0)
				{
					DBObjectModel.CCompany company = context.Companies.Where(c => c.Id == id).Single();
					context.Entry(company).Collection(c => c.Employees).Load();
					// implicit casting
					return (company);
				}
				return (null);
			}
		}

		public CCompanyController()
		{
		}
	}
}