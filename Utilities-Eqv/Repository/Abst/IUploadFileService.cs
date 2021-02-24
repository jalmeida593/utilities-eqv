using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities_Eqv.Model.Request;
using Utilities_Eqv.Model.Response;

namespace Utilities_Eqv.Repository.Abst
{
    public interface IUploadFileService
    {
        Task<UploadData> UploadFile(UploadDataRequest uploadDataRequest);
    }
}
