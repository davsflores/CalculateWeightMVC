using CalculateWeightMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Data
{
    internal class ComputedCostDAO
    {
        //connect to database

        //private string connectionString = @"Data Source=DESKTOP-9M2TMUQ;Initial Catalog=ComputeWeightMVCDb; Integrated Security=true";

        //public List<ComputedCostModel> FetchAll()
        //{
            //List<ComputedCostModel> ComputedCostModelList = new List<ComputedCostModel>();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    string sqlQuery = "Select * from ComputedCost";
            //    SqlCommand command = new SqlCommand(sqlQuery, connection);

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            ComputedCostModel computedc = new ComputedCostModel();
            //            computedc.computedcostid = reader.GetInt32(0);
            //            computedc.priority = reader.GetString(1);
            //            computedc.type = reader.GetString(2);
            //            computedc.weight = reader.GetInt32(3);
            //            computedc.cost = (double)reader.GetDecimal(4);
            //            computedc.totalcost = (double)reader.GetDecimal(5);

            //            ComputedCostModelList.Add(computedc);
            //        }

            //    }


            //}

            //return ComputedCostModelList;
        //    return View(;
        //}


        //public ComputedCostModel FetchOne(int computedcostid)
        //{
        //    //access the database
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "Select * from ComputedCost where computedcostid = @computedcostid";

        //        SqlCommand command = new SqlCommand(sqlQuery, connection);

        //        command.Parameters.Add("@computedcostid", System.Data.SqlDbType.Int, 100);
        //        command.Parameters["@computedcostid"].Value = computedcostid;
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        ComputedCostModel computedcostModel = new ComputedCostModel();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {

        //                computedcostModel.computedcostid = reader.GetInt32(0);
        //                computedcostModel.priority = reader.GetString(1);
        //                computedcostModel.type = reader.GetString(2);
        //                computedcostModel.weight = reader.GetInt32(3);
        //                computedcostModel.cost = (double)reader.GetDecimal(4);
        //                computedcostModel.totalcost = (double)reader.GetDecimal(5);

        //            }

        //        }
        //        return computedcostModel;

        //    }

        //}

        //public int CreateOrUpdate(ComputedCostModel computedcostModel)
        //{
        //    //access the database
        //    //if id > then update

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "Update ComputedCost Set weight = @weight, cost= @cost, totalcost = @totalcost where computedcostid =@id";

        //        SqlCommand command = new SqlCommand(sqlQuery, connection);
        //        command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = computedcostModel.computedcostid;
        //        command.Parameters.Add("@weight", System.Data.SqlDbType.Int, 1000).Value = computedcostModel.weight;
        //        command.Parameters.Add("@cost", System.Data.SqlDbType.Decimal, 2).Value = computedcostModel.cost;
        //        command.Parameters.Add("@totalcost", System.Data.SqlDbType.Decimal, 2).Value = computedcostModel.totalcost;

        //        connection.Open();

        //        int newID = command.ExecuteNonQuery();

        //        return newID;
        //    }

        //}

        //public int Create(ComputedCostModel computedcostModel)
        //{
        //    //access the database
        //    //if id > then update
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string sqlQuery = "Insert Into ComputedCost (@priority, @type, @weight, @cost, @totalcost)";

        //        SqlCommand command = new SqlCommand(sqlQuery, connection);
        //        command.Parameters.Add("@computedcostid", System.Data.SqlDbType.VarChar, 1000).Value = computedcostModel.computedcostid;
        //        command.Parameters.Add("@priority", System.Data.SqlDbType.VarChar, 1000).Value = computedcostModel.priority;
        //        command.Parameters.Add("@type", System.Data.SqlDbType.VarChar, 1000).Value = computedcostModel.type;
        //        command.Parameters.Add("@weight", System.Data.SqlDbType.Int,1000).Value = computedcostModel.weight;
        //        command.Parameters.Add("@cost", System.Data.SqlDbType.Decimal, 2).Value = computedcostModel.cost;
        //        command.Parameters.Add("@totalcost", System.Data.SqlDbType.Decimal, 2).Value = computedcostModel.totalcost;
        //        connection.Open();
        //        int newID = command.ExecuteNonQuery();

        //        return newID;
        //    }

        //}
    }
}