using gamestoolkit.api.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace gamestoolkit.api.Common
{
    public static class APIHelpers
    {
        public static IActionResult GetRestResponse(this BaseResponse baseResponse, ControllerBase instigator)
        {
            if (baseResponse == null)
            {
                return instigator.StatusCode((int)HttpStatusCode.InternalServerError);
            }

            switch (baseResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return instigator.Ok(baseResponse);
                case HttpStatusCode.NoContent:
                    return instigator.NoContent();
                case HttpStatusCode.NotFound:
                    return instigator.NotFound();
                case HttpStatusCode.Created:
                    return instigator.Created();
                default:
                    return instigator.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
