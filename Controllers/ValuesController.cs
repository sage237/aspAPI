using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication3.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public readonly IConfiguration config;
        public ValuesController( IConfiguration configurarion)
        {
            config = configurarion;
        }


        [HttpGet]
        [Route("GetEmps")]
        public string GetEmpolyee() {
          
            SqlConnection con =new SqlConnection(config.GetConnectionString("EmpConn").ToString());
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Customer", con);
            DataTable td = new DataTable();
            adapter.Fill(td);
            List<string> emp =new List<string>();
            if (td.Rows.Count > 0) {
                for (int i = 0; i < td.Rows.Count; i++) {
                    emp.Add(
                        "Id: " + td.Rows[i]["CustomerID"] +
                        " Name: " + td.Rows[i]["CustomerName"]
                        );
                }


            
            }
            return string.Join(',',emp);
        }

    }
}
