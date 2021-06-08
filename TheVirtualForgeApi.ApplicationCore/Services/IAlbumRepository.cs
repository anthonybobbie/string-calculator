using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVirtualForgeApi.ApplicationCore.Abstractions;
using TheVirtualForgeApi.ApplicationCore.DTO;
using TheVirtualForgeApi.ApplicationCore.Models;

namespace TheVirtualForgeApi.ApplicationCore.Services
{
    public interface IAlbumRepository   {
        Task<int> AddItemAsync(Album item);
        Task<Album> UpdateItemAsync(Album item);
        Task<List<Album>> GetItemsAsync();
        Task<bool> DeleteItemAsync(int itemID);
        Task<AlbumDTO> GetItemsAsync(string title, string artistName);
        
    }
    
   
}
