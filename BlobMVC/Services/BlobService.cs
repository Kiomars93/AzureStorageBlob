using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlobMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobMVC.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<IEnumerable<string>> ListBlobAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("justacontainer");
            var blobsList = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                blobsList.Add(blobItem.Name);
            }
            
            return blobsList;
        }
    }
}
