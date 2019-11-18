using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Supplier.API.Model
{    public interface ISupplierRepository
    {
        Task<Supplier> GetSupplierAsync(long id);
        Task<Supplier> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(long id);
    }
}
