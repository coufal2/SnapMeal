using System.IO;
using System.Threading.Tasks;

public class BlobService
{
	private readonly BlobContainerClient _containerClient;

	public BlobService(string connectionString, string containerName)
	{
		var blobServiceClient = new BlobServiceClient(connectionString);
		_containerClient = blobServiceClient.GetBlobContainerClient(containerName);
	}

	public async Task<string> UploadImageAsync(Stream imageStream, string imageName)
	{
		var blobClient = _containerClient.GetBlobClient(imageName);
		await blobClient.UploadAsync(imageStream);
		return blobClient.Uri.ToString();
	}
}
