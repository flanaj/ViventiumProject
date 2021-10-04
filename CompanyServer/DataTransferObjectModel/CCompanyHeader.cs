using System;

namespace CompanyServer.DataTransferObjectModel
{
	/// <summary>
	/// Summary description for CCompanyHeader
	/// </summary>
	public class CCompanyHeader
	{
		public int Id
		{
			get
			{
				return this.m_Id;
			}
		}

		public string Code
		{
			get
			{
				return this.m_Code;
			}
		}

		public string Description
		{
			get
			{
				return this.m_Description;
			}
		}

		public int EmployeeCount
		{
			get
			{
				return this.m_EmployeeCount;
			}
		}

		public CCompanyHeader(int id, string code, string description, int employeeCount)
		{
			this.m_Id = id;
			this.m_Code = code;
			this.m_Description = description;
			this.m_EmployeeCount = employeeCount;
		}

		private readonly int m_Id;
		private readonly string m_Code;
		private readonly string m_Description;
		private readonly int m_EmployeeCount;
	}
}