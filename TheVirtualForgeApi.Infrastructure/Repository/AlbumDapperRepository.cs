using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVirtualForgeApi.ApplicationCore.DTO;
using TheVirtualForgeApi.ApplicationCore.Models;
using TheVirtualForgeApi.ApplicationCore.Services;
using TheVirtualForgeApi.Infrastructure.Services;

namespace TheVirtualForgeApi.Infrastructure.Repository
{

    public class AlbumDapperRepository : IAlbumRepository 
    {
        private readonly DapperServiceClient serviceClient;
        private readonly ILogger<AlbumDapperRepository> logger;

        public AlbumDapperRepository(DapperServiceClient serviceClient, ILogger<AlbumDapperRepository> logger)
        {
            this.serviceClient = serviceClient;
            this.logger = logger;
        }

        public async Task<int> AddItemAsync(Album item)
        {
            logger.LogInformation("Add new album");
            string strquery = $@"
                                   INSERT INTO [dbo].[Album]([Title],[ArtistName], [AlbumTypeID],[Stock])
                                   VALUES(@Title ,@ArtistName,@AlbumTypeID  ,@Stock )
                               ";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", item.Title);
            parameters.Add("@ArtistName", item.ArtistName);
            parameters.Add("@AlbumTypeID", item.AlbumTypeID);
            parameters.Add("@Stock", item.Stock);
           return await this.serviceClient.ExecuteSingleAsync(strquery, parameters);

        }

        public async Task<bool> DeleteItemAsync(int Id)
        {
            logger.LogInformation("Deleting album ");
            string strquery = $@"Delete FROM Album WHERE Id=@Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            await this.serviceClient.ExecuteSingleAsync(strquery, parameters);
            return true;
        }

        public async Task<List<Album>> GetItemsAsync()
        {
            logger.LogInformation("Getting all albums ");
            string strquery = $@"SELECT Id,Title,ArtistName,Stock,AlbumTypeID FROM Album a";
            DynamicParameters parameters = new DynamicParameters();
            var response= await this.serviceClient.ExecuteAsync<Album>(strquery, parameters);
            return response;
        }

        public async Task<AlbumDTO> GetItemsAsync(string title, string artistName)
        {
            logger.LogInformation("Getting album ");
            string strquery = $@"
                                         SELECT a.Id,a.Title,a.ArtistName,a.Stock,at.Name [AlbumType]
                                         FROM Album a
                                         INNER JOIN AlbumTypes at on a.AlbumTypeID=at.Id
                                         WHERE a.Title=@title and a.ArtistName=@artistName
                                     ";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@title", title);
            parameters.Add("@artistName", artistName);
            var response= await this.serviceClient.ExecuteAsync<AlbumDTO>(strquery, parameters);
            return response.FirstOrDefault();
        }

        public async Task<Album> UpdateItemAsync(Album item)
        {
            logger.LogInformation("Updating album ");
            string strquery = $@"
                                  UPDATE [dbo].[Album]
                                  SET [Title] = @Title
                                 ,[ArtistName] = @ArtistName
                                 ,[AlbumTypeID] = @AlbumTypeID
                                 ,[Stock] = @Stock
                                  WHERE [Id]=@Id
                                 ";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Title", item.Title);
            parameters.Add("@ArtistName", item.ArtistName);
            parameters.Add("@AlbumTypeID", item.AlbumTypeID);
            parameters.Add("@Stock", item.Stock);
            parameters.Add("@Id", item.Id);
            var response = await this.serviceClient.ExecuteAsync<Album>(strquery, parameters);
            return response.FirstOrDefault();
        }

        

         
    }
}
