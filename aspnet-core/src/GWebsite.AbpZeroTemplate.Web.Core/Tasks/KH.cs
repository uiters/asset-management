using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

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
            Console.WriteLine("KH");
            try
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder
                {
                    DataSource = "THIEN-LAN",
                    InitialCatalog = "DbCS",
                    IntegratedSecurity = true
                };

                string connString = "Data Source=THIEN-LAN;Initial Catalog=DbCS;Integrated Security=True";

                //Be sure to replace <YourTable> with the actual name of the Table
                string queryString = "select * from Assets";
                Dictionary<string, int> map = new Dictionary<string, int>();
                Dictionary<string, int> mapprice = new Dictionary<string, int>();
                Dictionary<string, int> month = new Dictionary<string, int>();
                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = queryString;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["AssetCode"].ToString();
                            //int month = int.Parse(reader["MonthDepreciation"].ToString());
                            int originalprice = int.Parse(reader["OriginalPrice"].ToString());
                            // map.Add(id, month);
                            mapprice.Add(id, originalprice);
                        }
                    }
                }
                string queryString1 = "Select * From Depreciations Where DAY(DayBeginCalculateDepreciation) = " + DateTime.Now.Day.ToString();

                using (SqlConnection connection = new SqlConnection(connString))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = queryString1;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["AssetCode"].ToString();
                            int depreciatedvalue = int.Parse(reader["DepreciatedValue"].ToString());
                            int depreciationmonth = int.Parse(reader["DepreciationMonths"].ToString());
                            //int originalprice = int.Parse(reader["OriginalPrice"].ToString());
                            //map.Add(id, month);
                            map.Add(id, depreciatedvalue);
                            month.Add(id, depreciationmonth);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> asset in map)
                {
                    try
                    {
                        AssetDto assets = new AssetDto();
                        using (SqlConnection connection = new SqlConnection(connString))
                        using (SqlCommand command = connection.CreateCommand())
                        {

                            foreach (KeyValuePair<string, int> assetprice in mapprice)
                            {
                                if (asset.Key == assetprice.Key)
                                {
                                    assets.OriginalPrice = assetprice.Value;
                                    break;
                                }
                            }
                            foreach (KeyValuePair<string, int> assetmonth in month)
                            {
                                if (asset.Key == assetmonth.Key)
                                {
                                    assets.DepreciationMonths = assetmonth.Value;
                                    break;
                                }
                            }

                            //assets.MonthDepreciation = asset.Value;
                            int depreciatedvalue = asset.Value+(int)CalculateDepreciation(assets.OriginalPrice, assets.DepreciationMonths);
                            depreciatedvalue = depreciatedvalue > assets.OriginalPrice ? assets.OriginalPrice : depreciatedvalue;
                            float remainingvalue = (assets.OriginalPrice - depreciatedvalue)>=0?(assets.OriginalPrice - depreciatedvalue):0;
                            command.CommandText = "UPDATE Depreciations SET DepreciatedValue = " + depreciatedvalue.ToString() + ", RemainingValue = " + remainingvalue.ToString() + " WHERE AssetCode = '" + asset.Key.ToString() + "'";
                            //command.CommandText = "Select * From Depreciations Where DAY(DayBeginCalculateDepreciation) = " + DateTime.Now.Day.ToString();
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
        public double CalculateDepreciation(double originalPrice, int totalMonths = 0)
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
            string connectionStr = @"Data Source=THIEN-LAN;Initial Catalog=DbCS;Integrated Security=True";
            string query = "UPDATE Assets SET DepreciationValue = " + CalculateDepreciation(asset.OriginalPrice, asset.DepreciationMonths);
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
