using System;
using System.Collections.Generic;

namespace CompanyServer.DataTransferObjectModel
{
	/// <summary>
	/// Summary description for CCompany
	/// </summary>
	public class CCompany : CCompanyHeader
	{
		public CEmployeeHeader[] Employees
        {
            get
            {
				return (this.m_Employees);
            }
        }

		public CCompany(int id, string code, string description, IList<DBObjectModel.CEmployee> employees) : base (id, code, description, employees.Count)
        {
			int i = 0;
			this.m_Employees = new CEmployeeHeader[employees.Count];
			foreach (DBObjectModel.CEmployee employee in employees)
            {
				this.m_Employees[i++] = employee;
            }
        }

		private CEmployeeHeader[] m_Employees;
	}
}
