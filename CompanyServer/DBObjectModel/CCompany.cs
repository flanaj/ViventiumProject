using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyServer.DBObjectModel
{
    /// <summary>
    /// Summary description for CCompany
    /// </summary>
    public class CCompany
    {
        public static implicit operator DataTransferObjectModel.CCompany(CCompany company)
        {
           return new DataTransferObjectModel.CCompany(company.Id, company.Code, company.Description, company.Employees);
        }        

        public int Id
        {
            get;
            set;
        }

        [MaxLength(100)]
        public string Code
        {
            get;
            set;
        }

        [MaxLength(500)]
        public string Description
        {
            get;
            set;
        }

        public IList<CEmployee> Employees { get; set; }
    }
}