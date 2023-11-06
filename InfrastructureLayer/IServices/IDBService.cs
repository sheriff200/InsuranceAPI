using DataAccessLayer.Model.Dto.Response;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.IServices
{
    public interface IDBService
    {
        Task<int> Add<T>(T model);
        void AddList<T>(List<T> model);
        Task<WebApiResponse> Delete<T>(int id);
        Task<int> Update<T>(T model);
        Task<WebApiResponse> GetAuthorizedUserByUserName<T>(string id);
        IEnumerable<T> GetAll<T>();
        Task<Page<T>> GetRecords<T>(long pagenumber, long pagesize);
    }
}
