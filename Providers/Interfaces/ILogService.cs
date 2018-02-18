using System;
using System.Threading.Tasks;

namespace Providers.Interfaces
{
    public interface ILogService
    {
        Task LogError(Exception ex);
            

    }
}
