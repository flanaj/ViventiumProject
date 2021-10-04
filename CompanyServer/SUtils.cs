using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServer
{
    public class SUtils
    {
		public static IEnumerable<Dictionary<string, string>> ParseCSVData(string csvData)
		{
			string[] rows = csvData.Split('\n');
			string[] headers = rows[0].Split(',');

			for (int i = 1; i < rows.Length; i++)
			{
				string[] cols = rows[i].Split(',');
				if (cols.Length == headers.Length)
				{
					Dictionary<string, string> row = new Dictionary<string, string>();
					for (int j = 0; j < headers.Length; j++)
					{
						row.Add(headers[j], cols[j]);
					}
					yield return row;
				}
			}
		}

	}
}
