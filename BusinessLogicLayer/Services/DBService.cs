using DataAccessLayer.Model.Dto.Response;
using DataAccessLayer.Serilog;
using InfrastructureLayer.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{

    public class DBService : IDBService
    {
        private readonly IConfiguration _config;
        private string insuranceconnectionString = "InsuranceDbConnectionString";
        private readonly string directory = "DBLogService";
        private readonly ISerilogger _seriLogger;
        public DBService(IConfiguration config, ISerilogger seriLogger)
        {
            _config = config;
            _seriLogger = seriLogger;
        }

        public IDatabase insuranceconnection
        {
            get
            {
                SqlConnection con = new SqlConnection(_config.GetConnectionString(insuranceconnectionString));
                return new Database(con);
            }
        }


        public async Task<int> Add<T>(T model)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                       var data = await db.InsertAsync(model);
                        return 1;
                    }
                    finally
                    {
                        db.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"DBLogService --Insert request =>"}{JsonConvert.SerializeObject(model)}{ex.ToString()}", false, directory);

                    return 0;
                }
            }
        }




        public async void AddList<T>(List<T> model)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        db.BeginTransaction();
                        await db.InsertBatchAsync(model);
                        db.CompleteTransaction();
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"DBLogService --AddList request =>"}{JsonConvert.SerializeObject(model)}{ex.ToString()}", false, directory);

                    db.AbortTransaction();
                }
            }
        }

        public async Task<WebApiResponse> Delete<T>(int id)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        await Task.FromResult(db.Delete<T>(id));
                        return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Deletion was successful for record with the id " + id };
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"DBLogService --delete request =>"}{JsonConvert.SerializeObject(id)}{ex.ToString()}", false, directory);

                    return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Internal server error occurred " + ex.ToString() };
                }

            }
        }


        public async Task<int> Update<T>(T model)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        await db.UpdateAsync(model);
                        return 1;
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"DBLogService --update request =>"}{JsonConvert.SerializeObject(model)}{ex.ToString()}", false, directory);

                    return 0;
                }
            }
        }


        public async Task<WebApiResponse> GetAuthorizedUserByUserName<T>(string id)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        var result = await Task.FromResult(db.FirstOrDefault<T>(@"exec dbo.sp_GetAuthorizedUserByUsername @UserName", new { UserName = id }));
                        return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Record was successfully retrieved", Data = result };
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"GetAuthorizedUserByUserName request =>"}{JsonConvert.SerializeObject(id)}{ex.ToString()}", false, directory);

                    return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Internal server error occurred " + ex.ToString(), Data = null };

                }

            }
        }



        public async Task<Page<T>> GetRecords<T>(long pagenumber, long pagesize)
        {
            var result = new Page<T>();
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        result = await db.PageAsync<T>(pagenumber, pagesize, "SELECT c.Id, c.ClaimID, c.AppStage, c.NationalIDNumber, c.ClaimStatus, c.ExpenseAmount, c.ExpenseDate, c.Expenses,PolicyHolders.DateofBirth,PolicyHolders.Name,PolicyHolders.PolicyNumber,PolicyHolders.Surname FROM Claims, PolicyHolders\r\n   inner join Claims c on c.NationalIDNumber = PolicyHolders.NationalIDNumber WHERE Claims.NationalIDNumber = PolicyHolders.NationalIDNumber");
                          return result;
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"GetByID =>"}{ex.ToString()}", false, directory);
                    return result;
                }

            }
        }


        public IEnumerable<T> GetAll<T>()
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        return db.Fetch<T>();
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"GetAll =>"}{ex.ToString()}", false, directory);

                    return null;
                }

            }
        }



        public async Task<WebApiResponse> GetByID<T>(string id)
        {
            using (IDatabase db = insuranceconnection)
            {
                try
                {
                    try
                    {
                        db.Connection.Open();
                        var result = await db.SingleByIdAsync<T>(id);
                        return new WebApiResponse { ResponseCode = ApiResponseCode.Success, StatusCode = ApiResponseCode.StatusOk, Message = "Record was successfully retrieved", Data = result };
                    }
                    finally
                    {
                        db.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    _seriLogger.LogRequest($"{"GetByID =>"}{ex.ToString()}", false, directory);
                    return new WebApiResponse { ResponseCode = ApiResponseCode.Failed, StatusCode = ApiResponseCode.Failed, Message = "Internal server error occurred " + ex.ToString() };
                }

            }
        }



        public class PagedList<T> : List<T>
        {
            public int CurrentPage { get; private set; }
            public int TotalPages { get; private set; }
            public int PageSize { get; private set; }
            public int TotalCount { get; private set; }
            public bool HasPrevious => CurrentPage > 1;
            public bool HasNext => CurrentPage < TotalPages;
            public PagedList(List<T> items, int count, int pageNumber, int pageSize)
            {
                TotalCount = count;
                PageSize = pageSize;
                CurrentPage = pageNumber;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                AddRange(items);
            }
            public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
            {
                var count = source.Count();
                var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                return new PagedList<T>(items, count, pageNumber, pageSize);
            }
        }

    }

}
