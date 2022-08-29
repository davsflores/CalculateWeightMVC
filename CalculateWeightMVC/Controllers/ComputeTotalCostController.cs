using CalculateWeightMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace CalculateWeightMVC.Controllers
{
    public class ComputeTotalCostController : Controller
    {

        string connectionString = @"Data Source=DESKTOP-9M2TMUQ;Initial Catalog=ComputeWeightMVCDb; Integrated Security=true";
        // GET: ComputeTotalCost
        public ActionResult Index()
        {

            return View(new ComputeTotalCost());
        }

        [HttpPost]
        public ActionResult Index(ComputeTotalCost c, string calculate)
        {
            int num = c.itemweight;
            bool isNum = int.TryParse(c.ToString(), out num);

            if (isNum || c.itemweight > 0)
            {
                string priority, type;
                decimal cost;

                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    SqlCommand sqlcom = new SqlCommand("Select priority, type, cost From Weight where minweight <= '" + c.itemweight + "' And maxweight >= '" + c.itemweight + "'", sqlConn);
                    sqlConn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        priority = (string)dt.Rows[0][0];
                        type = (string)dt.Rows[0][1];
                        cost = (decimal)dt.Rows[0][2];
                    }
                    sqlConn.Close();
                }

                decimal itemtc = c.itemtotalcost;
                decimal itemw = c.itemweight;

                if (calculate == "multiply")
                {
                    itemtc = (itemw * cost);
                }

                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    sqlConn.Open();
                    var sql = "insert into ComputedCost( priority, type, weight, cost, totalcost) VALUES ( @priority, @type, @itemw, @cost, @itemtc)";
                    using (var cmd = new SqlCommand(sql, sqlConn))
                    {
                        cmd.Parameters.AddWithValue("@priority", priority);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@itemw", itemw);
                        cmd.Parameters.AddWithValue("@cost", cost);
                        cmd.Parameters.AddWithValue("@itemtc", itemtc);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            else
            {
                string message = "Please input only numbers greater than 0";
                string title = "Warning";
                MessageBox.Show(message, title);

            }
            c.itemweight = 0;
            return View(c);
        }

    }
}