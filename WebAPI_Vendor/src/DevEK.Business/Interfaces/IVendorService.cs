using System;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Services
{
    public interface IVendorService : IDisposable
    {
        Task<bool> Add(Vendor vendor);

        Task<bool> Update(Vendor vendor);

        Task<bool> Remove(Guid id);

        Task UpdateAddress(Address address);

    }
}