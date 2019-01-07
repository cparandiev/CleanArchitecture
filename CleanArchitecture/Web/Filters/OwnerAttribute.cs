using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Web.Constants.Claim;

namespace Web.Filters
{
    class ClaimIds
    {
        public int? UserId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
    }

    public class OwnerFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var currentUserClaimIds = await ExtractCurrentUserClaimIds(context.HttpContext);
            var pathParametersIds = await ExtractPathParametersIds(context);

            if(! await Validate(pathParametersIds, currentUserClaimIds))
            {
                throw new UnauthorizedAccessException();
            }

            await next();
        }

        private Task<bool> Validate(ClaimIds requiredClaimIds, ClaimIds currentClaimIds)
        {
            if(requiredClaimIds.UserId != null && currentClaimIds.UserId != requiredClaimIds.UserId){
                return Task.FromResult(false);
            }
            if (requiredClaimIds.DoctorId != null && currentClaimIds.DoctorId != requiredClaimIds.DoctorId){
                return Task.FromResult(false);
            }
            if (requiredClaimIds.PatientId != null && currentClaimIds.PatientId != requiredClaimIds.PatientId){
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        private Task<ClaimIds> ExtractPathParametersIds(ActionExecutingContext context)
        {
            Dictionary<string, object> pathParameters = context.ActionArguments
                .Where(a => new[] { UserClaimsNames.USER_ID, UserClaimsNames.DOCTOR_ID, UserClaimsNames.PATIENT_ID }.Contains(a.Key))
                .ToDictionary(x => x.Key, x => x.Value);


            return Task.FromResult(new ClaimIds {
                UserId = pathParameters.ContainsKey(UserClaimsNames.USER_ID) ? pathParameters[UserClaimsNames.USER_ID]?.ToString()?.ToNullableInt() : null,
                PatientId = pathParameters.ContainsKey(UserClaimsNames.PATIENT_ID) ? pathParameters[UserClaimsNames.PATIENT_ID]?.ToString()?.ToNullableInt() : null,
                DoctorId = pathParameters.ContainsKey(UserClaimsNames.DOCTOR_ID) ? pathParameters[UserClaimsNames.DOCTOR_ID]?.ToString()?.ToNullableInt() : null
            });
        }

        private Task<ClaimIds> ExtractCurrentUserClaimIds(HttpContext context)
        {
            var userClaims = context.User.Claims;

            var userId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.USER_ID);
            var patientId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.PATIENT_ID);
            var doctorId = userClaims.FirstOrDefault(c => c.Type == UserClaimsNames.DOCTOR_ID);

            return Task.FromResult(new ClaimIds {
                UserId = userId?.Value?.ToString()?.ToNullableInt(),
                PatientId = patientId?.Value?.ToString()?.ToNullableInt(),
                DoctorId = doctorId?.Value?.ToString()?.ToNullableInt()
            });
        }

        //private async Task<ClaimIds> ExtractBodyRequestIds(HttpContext context) {
        //    var t = await ReadBodyAsString(context);

        //    return JsonConvert.DeserializeObject<ClaimIds>(t);
        //}

        //private async Task<string> ReadBodyAsString(HttpContext context)
        //{
        //    context.Request.EnableRewind();
        //    var initialBody = context.Request.Body; // Workaround
            
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
        //        {
        //            return await reader.ReadToEndAsync();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //    finally
        //    {
        //        // Workaround so MVC action will be able to read body as well
        //        context.Request.Body = initialBody;
        //        //context.Request.Body.Position = 0;
        //    }
        //}
    }
}
