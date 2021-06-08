using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVirtualForgeApi.ApplicationCore.Abstractions
{
    /// <summary>
    /// Common interface for data CRUD operations
    /// </summary>
    public interface IRepository<T>
    {
        Task AddItemAsync(T item);
        Task<T> UpdateItemAsync(T item);
        Task<List<T>> GetItemsAsync();
        Task<bool> DeleteItemAsync(int itemID);

    }
}
