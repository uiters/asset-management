using GWebsite.AbpZeroTemplate.Application.Share.Assets.Dto;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
//using System.Threading.Tasks;
using Abp;
using Abp.Localization;
using Abp.Notifications;
using GSoft.AbpZeroTemplate.Authorization.Users;
using GSoft.AbpZeroTemplate.MultiTenancy;
using GSoft.AbpZeroTemplate;
using GSoft.AbpZeroTemplate.Notifications;
using Abp.Dependency;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;

namespace QuartzWithCore.Tasks
{
    public class KH : IJob
    {
        //private readonly INotificationPublisher _notificationPublisher;

        /// <summary>
        /// Calculate Depreciation
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Start</param>
        /// <param name="originalPrice">Original Price</param>
        /// <returns>Depreciation</returns>
        /// 
        public async Task Execute(IJobExecutionContext context)
        {
            //_notificationPublisher = notificationPublisher;
            Console.WriteLine("KH");
            //this.WelcomeToTheApplicationAsync()
            //try
            // {
            INotificationPublisher notificationPublisher = IocManager.Instance.IocContainer.Resolve<INotificationPublisher>();
            IRepository<User, long> userRepository = IocManager.Instance.IocContainer.Resolve<IRepository<User, long>>();
            var admin = (await userRepository.GetAllListAsync()).Where(x => x.Name == "admin").FirstOrDefault();
            //IRepository<User, long> userRepository = IocManager.Instance.IocContainer.Resolve<IRepository<User, long>>();

            var user = admin.ToUserIdentifier();

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-OAVL1J3",
                InitialCatalog = "gwebsite",
                IntegratedSecurity = true
            };

            string connString = "Data Source=DESKTOP-OAVL1J3;Initial Catalog=gwebsite;Integrated Security=True";

            //Be sure to replace <YourTable> with the actual name of the Table
            string queryString = "select * from Assets";
            Dictionary<string, int> map = new Dictionary<string, int>();
            Dictionary<string, int> mapprice = new Dictionary<string, int>();
            Dictionary<string, string> name = new Dictionary<string, string>();
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
                        string assetname = reader["AssetName"].ToString();
                        // map.Add(id, month);
                        mapprice.Add(id, originalprice);
                        name.Add(id, assetname);
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
                        foreach (KeyValuePair<string, string> assetname in name)
                        {
                            if (asset.Key == assetname.Key)
                            {
                                assets.AssetName = assetname.Value;
                                break;
                            }
                        }
                        //assets.MonthDepreciation = asset.Value;
                        int depreciatedvalue = asset.Value + (int)CalculateDepreciation(assets.OriginalPrice, assets.DepreciationMonths);
                        depreciatedvalue = depreciatedvalue > assets.OriginalPrice ? assets.OriginalPrice : depreciatedvalue;
                        float remainingvalue = (assets.OriginalPrice - depreciatedvalue) >= 0 ? (assets.OriginalPrice - depreciatedvalue) : 0;
                        command.CommandText = "UPDATE Depreciations SET DepreciatedValue = " + depreciatedvalue.ToString() + ", RemainingValue = " + remainingvalue.ToString() + " WHERE AssetCode = '" + asset.Key.ToString() + "'";
                        //command.CommandText = "Select * From Depreciations Where DAY(DayBeginCalculateDepreciation) = " + DateTime.Now.Day.ToString();
                        Console.WriteLine(command.CommandText);
                        connection.Open();

                        await notificationPublisher.PublishAsync(
                                AppNotificationNames.WelcomeToTheApplication,
                                new MessageNotificationData("Da Khau Hao Tai San " + assets.AssetName),
                                severity: NotificationSeverity.Success,
                                userIds: new[] { user }
                                );
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
            string connectionStr = @"Data Source=DESKTOP-OAVL1J3;Initial Catalog=gwebsite;Integrated Security=True";
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
