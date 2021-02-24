using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utilities_Eqv.Model.Request;
using Utilities_Eqv.Model.Response;
using Utilities_Eqv.Repository.Abst;

namespace Utilities_Eqv.Repository.Impl
{
    public class UploadFileService:IUploadFileService
    {
        private readonly ILogger<UploadFileService> _logger;
        private string connectionString;
        public UploadFileService(ILogger<UploadFileService> logger, IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
            _logger = logger;
        }
        public async Task<UploadData> UploadFile(UploadDataRequest uploadDataRequest)
        {
            UploadData Resp = new UploadData();
            //condicion para crear un contenedor
            uploadDataRequest.Contenedor = uploadDataRequest.Contenedor.ToLower();

            var cliente = new BlobContainerClient(connectionString, uploadDataRequest.Contenedor);
            try
            {
                await cliente.CreateIfNotExistsAsync();
                cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                var extension = Path.GetExtension(uploadDataRequest.File.FileName);
                var archivoNombre = $"{uploadDataRequest.NombreArchivo}{extension}";
                var blob = cliente.GetBlobClient(archivoNombre);
                await blob.UploadAsync(uploadDataRequest.File.OpenReadStream());

                Resp.Url = blob.Uri.ToString();
                Resp.Message = "Documento Cargado Correctamente";
                Resp.Status = "Ok";
            }
            catch(Exception e)
            {
                Resp.Url = string.Empty;
                Resp.Message = e.Message;
                Resp.Status = "Error";
            }
            return Resp;
        }
    }
}
