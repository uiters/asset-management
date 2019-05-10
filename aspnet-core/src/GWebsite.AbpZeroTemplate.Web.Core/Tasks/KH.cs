using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using GWebsite.AbpZeroTemplate.Application.Share.Assets;
using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using System.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace QuartzWithCore.Tasks
{
    public class KH : IJob
    {
        /// <summary>
        /// Calculate Depreciation
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Start</param>
        /// <param name="originalPrice">Original Price</param>
        /// <returns>Depreciation</returns>
        /// 
        public Task Execute(IJobExecutionContext context)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = "DESKTOP-OAVL1J3";
            csb.InitialCatalog = "gwebsite3";
            csb.IntegratedSecurity = true;

            string connString = "Data Source=DESKTOP-OAVL1J3;Initial Catalog=gwebsite3;Integrated Security=True";

            //Be sure to replace <YourTable> with the actual name of the Table
            string queryString = "select * from Assets";
            var map = new Dictionary<int, int>();
            var mapprice = new Dictionary<int, int>();
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        int month = int.Parse(reader["MonthDepreciation"].ToString());
                        int originalprice = int.Parse(reader["OriginalPrice"].ToString());
                        map.Add(id, month);
                        mapprice.Add(id, originalprice);
                    }
                }
            }
            foreach (KeyValuePair<int, int> asset in map)
            {
                try
                {
                    
                        using (SqlConnection connection = new SqlConnection(connString))
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            AssetDto assets = new AssetDto();
                            foreach (KeyValuePair<int, int> assetprice in mapprice)
                            {
                                if(asset.Key==assetprice.Key)
                                {
                                    assets.OriginalPrice = assetprice.Value;
                                    break;
                                }
                            }
                            assets.MonthDepreciation = asset.Value;
                            command.CommandText = "UPDATE Depreciations SET RemainingValue = " + calculateDepreciation(assets.OriginalPrice, assets.MonthDepreciation).ToString() + " WHERE AssetId = " + asset.Key.ToString() + " AND DAY(DayBeginCalculateDepreciation) = "+DateTime.Now.Day.ToString();
                            Console.WriteLine(command.CommandText);
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {


                                }
                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return Task.FromResult(0);
        }
        public double calculateDepreciation(double originalPrice, int totalMonths = 0)
        {
            return totalMonths <= 1 ? originalPrice : originalPrice / totalMonths;
        }
        public void AddParameter(string query, object[] parameter, SqlCommand command)
        {
            if (parameter != null)
            {
                string[] listParameter = query.Split(' ');
                int i = 0;
                foreach (string item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        ++i;
                    }
                }
            }
        }
        public int Execute(AssetDto asset, object[] parameter = null)
        {
            if (DateTime.Now.Day != 25)
            {
                return 0;
            }
            int data = 0;
            string connectionStr = @"Data Source=DESKTOP-0TVNIA1;Initial Catalog=gwebsite;Integrated Security=True";
            string query = "UPDATE Assets SET DepreciationValue = " + calculateDepreciation(asset.OriginalPrice, asset.MonthDepreciation);
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameter(query, parameter, command);
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
    }
}
