using System;
using System.Threading.Tasks;

namespace WMI_NetCore_API.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}