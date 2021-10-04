using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyServer.DBObjectModel
{
    /// <summary>
    /// Summary description for CEmployee
    /// </summary>
    public class CEmployee
    {
        public static implicit operator DataTransferObjectModel.CEmployeeHeader(CEmployee employee)
        {
            return new DataTransferObjectModel.CEmployeeHeader(employee.Id, employee.FirstName, employee.LastName);
        }

        public int Id
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string FirstName
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string LastName 
        {
            get;
            set;
        }

        [MaxLength(100)]
        public string Email 
        {
            get;
            set;
        }

        [MaxLength(100)]
        public string Department 
        { 
            get; 
            set; 
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime HireDate 
        { 
            get; 
            set; 
        }

        public CCompany Company 
        { 
            get; 
            set; 
        }

        public int CompanyId 
        { 
            get; 
            set; 
        }
    }
}