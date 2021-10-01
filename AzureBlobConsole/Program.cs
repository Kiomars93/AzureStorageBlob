using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureBlobConsole
{
    class Program
    {
        static string connectionstring = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
        static string containerName = "justacontainer";
        static string filename = "Network1.jpg";
        static string filepath = "./data/Network1.png";
        static void Main()
        {
            CreateBlob().Wait();
            //GetBlob().Wait();
        }
        static async Task CreateBlob()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionstring);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(filename);
            using FileStream uploadFileStream = File.OpenRead(filepath);
            // Raden nedan möjliggör så att man kan displaya bilden direkt via browsers istället för
            // det ska laddas ner
            var blobHttpHeader = new BlobHttpHeaders { ContentType = "image/jpg" };
            await blobClient.UploadAsync(uploadFileStream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            //await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
            Console.WriteLine("Blob created!");
        }

        static string downloadpath = "./data/Network1.png";
        static async Task GetBlob()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionstring);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blob = containerClient.GetBlobClient(filename);
            BlobDownloadInfo blobdata = await blob.DownloadAsync();
            using (FileStream downloadFileStream = File.OpenWrite(downloadpath))
            {
                await blobdata.Content.CopyToAsync(downloadFileStream);
                downloadFileStream.Close();
            }
            Console.WriteLine("Blob Downloaded!");
        }
    }
}
