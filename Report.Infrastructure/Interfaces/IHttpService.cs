using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Report.Infrastructure.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(Uri uri, Dictionary<string, string> headers = null)
                   where T : class;
    }
}
