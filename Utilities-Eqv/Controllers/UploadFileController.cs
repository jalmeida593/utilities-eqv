using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities_Eqv.Model.Request;
using Utilities_Eqv.Model.Response;
using Utilities_Eqv.Repository.Abst;

namespace Utilities_Eqv.Controllers
{
    [ApiController]
    [Route("api/utilities/Upload-Azure-Storage")]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFileService _uploadFile;
        private readonly ILogger<UploadFileController> _logger;

        public UploadFileController(ILogger<UploadFileController> logger,IUploadFileService uploadFile)
        {
            _uploadFile = uploadFile;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene el ruta, nombre, archivo para carga en Azure Storage.
        /// </summary>
        /// <param name="uploadDataRequest">Objeto De Carga de Datos</param>
        /// <returns>Objeto UploadData</returns>
        //[HttpPost("api/utilities/Upload-Azure-Storage")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UploadData))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorEntity))]
        public async Task<ActionResult<UploadData>> Post([FromForm] UploadDataRequest uploadDataRequest)
        {
            if (uploadDataRequest.File.Length > 0)
            {
                try
                {
                    return Ok(await _uploadFile.UploadFile(uploadDataRequest));
                }
                catch (Exception ex)
                {
                    ErrorEntity error = new ErrorEntity
                    {
                        Type = "Exception",
                        Message = ex.Message,
                        Code = 500,
                        Name = "Error-Utilitarios-Api"
                    };
                    return BadRequest(error);
                }
            }
            else
            {
                ErrorEntity error = new ErrorEntity
                {
                    Type = "Exception",
                    Message = "Error-Verificar el Archivo",
                    Code = 500,
                    Name = "Error-Verificar el Archivo"
                };
                return BadRequest(error);
            }
        }
    }
}
