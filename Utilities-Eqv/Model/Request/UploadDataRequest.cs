using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Utilities_Eqv.Model.Response;

namespace Utilities_Eqv.Model.Request
{
    /// <summary>
    /// Datos del Archivo a Cargar
    /// </summary>
    public class UploadDataRequest
    {
        [Required]
        [StringLength(maximumLength: 300)]
        /// <summary>
        /// Nombre del Archivo a Cargar en Azure Storage
        /// </summary>
        public string NombreArchivo { get; set; }

        [Required]
        [StringLength(maximumLength: 25)]
        /// <summary>
        /// Nombre del Contenedor a Crear en Azure Storage
        /// </summary>
        public string Contenedor { get; set; }
        [Required]
        /// <summary>
        /// Archivo a cargar en Azure Storage
        /// </summary>
        public IFormFile File { get; set; }
    }
}
