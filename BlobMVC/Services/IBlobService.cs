using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobMVC.Services
{
    public interface IBlobService
    {
        public Task<IEnumerable<string>> ListBlobAsync();
    }
}
