using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities_Eqv.Model.Response
{
    public class UploadData
    {
        /// <summary>
        /// Url del Archivo Cargado
        /// </summary>
        [Column("Url")]
        public string Url { get; set; }

        /// <summary>
        /// Status del proceso
        /// </summary>
        [Column("Status")]
        public string Status { get; set; }

        /// <summary>
        /// Mensaje del proceso
        /// </summary>
        [Column("Message")]
        public string Message { get; set; }
    }
}
