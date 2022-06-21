using BlogWebApplication.Dto.Request;
using BlogWebApplication.Dto.Response;
using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.Abstract
{
    public interface IWriterService:IService<Writer>
    {
        IList<Writer> GetWriters();
        Writer GetWriter(string userName);
        Task<IList<WriterListResponse>> GetAllAsyncDto();
        Task<bool> AddAsyncDto(AddWriterRequest writer);
        int GetWriterID(string mail);
    }
}
