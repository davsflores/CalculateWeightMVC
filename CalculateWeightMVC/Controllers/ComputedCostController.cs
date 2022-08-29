using CalculateWeightMVC.Data;
using CalculateWeightMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculateWeightMVC.Controllers
{

  public class ComputedCostController : Controller
    {
        private string connectionString = @"Data Source=DESKTOP-9M2TMUQ;Initial Catalog=ComputeWeightMVCDb; Integrated Security=true";

        public ActionResult Index()
        {
            DataTable dtblComputedCost = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From ComputedCost", sqlCon);
                sqlDa.Fill(dtblComputedCost);
            }

            return View(dtblComputedCost);
        }

        public ActionResult Edit(int id)
        {
            ComputedCostModel computedcostModel = new ComputedCostModel();
            DataTable dtblComputedCost = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Select * from ComputedCost where computedcostid = @computedcostid";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@computedcostid", id);
                sqlDa.Fill(dtblComputedCost);

            }
            if (dtblComputedCost.Rows.Count == 1)
            {
                computedcostModel.computedcostid = Convert.ToInt32(dtblComputedCost.Rows[0][0].ToString());
                computedcostModel.priority = dtblComputedCost.Rows[0][1].ToString();
                computedcostModel.type = dtblComputedCost.Rows[0][2].ToString();
                computedcostModel.weight = Convert.ToInt32(dtblComputedCost.Rows[0][3].ToString());
                computedcostModel.cost = Convert.ToDouble(dtblComputedCost.Rows[0][4].ToString());
                computedcostModel.totalcost = Convert.ToDouble(dtblComputedCost.Rows[0][5].ToString());
                return View(computedcostModel);
            }
            else

                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ComputedCostModel cm, ComputeTotalCost c)
        {
            string priority, type;
            decimal cost;

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand("Select priority, type, cost From Weight where minweight <= '" + cm.weight + "' And maxweight >= '" + cm.weight + "'", sqlConn);
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

            decimal itemtc;
            int itemw = (int)cm.weight;
            itemtc = (itemw * cost);
        
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Update ComputedCost Set priority = @priority , type = @type , weight = @weight , cost = @cost , totalcost = @totalcost where computedcostid =  '" + cm.computedcostid +"'";
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@computedcostid", cm.computedcostid);
                command.Parameters.AddWithValue("@priority", priority);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@weight", cm.weight);
                command.Parameters.AddWithValue("@cost", cost);
                command.Parameters.AddWithValue("@totalcost", itemtc);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ComputedCostModel computedcostModel = new ComputedCostModel();
            DataTable dtblComputedCost = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Select * from ComputedCost where computedcostid = @computedcostid";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@computedcostid", id);
                sqlDa.Fill(dtblComputedCost);

            }
            if (dtblComputedCost.Rows.Count == 1)
            {
                computedcostModel.computedcostid = Convert.ToInt32(dtblComputedCost.Rows[0][0].ToString());
                computedcostModel.priority = dtblComputedCost.Rows[0][1].ToString();
                computedcostModel.type = dtblComputedCost.Rows[0][2].ToString();
                computedcostModel.weight = Convert.ToInt32(dtblComputedCost.Rows[0][3].ToString());
                computedcostModel.cost = Convert.ToDouble(dtblComputedCost.Rows[0][4].ToString());
                computedcostModel.totalcost = Convert.ToDouble(dtblComputedCost.Rows[0][5].ToString());
                return View(computedcostModel);
            }
            else

                return RedirectToAction("Index");
        }

    }

}