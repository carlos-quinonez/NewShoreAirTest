using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Repositories;

public interface IRepository
{
    Task<HttpResponseWrapper<T>> Get<T>(string url);
}

