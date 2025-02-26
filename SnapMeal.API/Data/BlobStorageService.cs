using Azure.Storage.Blobs;
using System.IO;
using System.Threading.Tasks;

namespace SnapMeal.API.Data
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "recipes";

        public BlobStorageService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            var con
