using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServer.DataTransferObjectModel
{
    public class CEmployeeHeader
    {
        public int Id
        {
            get
            {
                return (this.m_Id);
            }
        }

        public string FullName
        {
            get
            {
                return (string.Format("{0} {1}", this.m_FirstName, this.m_LastName));
            }
        }

        public CEmployeeHeader(int id, string firstName, string lastName)
        {
            this.m_Id = id;
            this.m_FirstName = firstName;
            this.m_LastName = lastName;
        }

        private int m_Id;
        private string m_FirstName;
        private string m_LastName;
    }
}
