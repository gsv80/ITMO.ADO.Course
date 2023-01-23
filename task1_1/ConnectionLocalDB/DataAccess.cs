using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConnectionLocalDB
{
    public class DataAccess
    {
        public List<Territory> GetTerritory(string territory)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("NorthwndDb")))
            {
                var output = connection.Query<Territory>($"select * from Territories where TerritoryDescription = '{territory}' ").ToList();
                return output;
            }   
        }
    }
}
 