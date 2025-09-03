//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Identity.Client;
//using Microsoft.PowerBI.Api.Models;
//using Microsoft.PowerBI.Api;
//using Microsoft.Rest;
//using System.Data;
//using System.Text.RegularExpressions;

//namespace CourseApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PowerBIController : ControllerBase
//    {{
//    private readonly string clientId = "5ea68158-662c-4531-851c-064c35036ffc\r\n";
//        private readonly string clientSecret = "~ab8Q~oVCOeekfrqz7-URNHd7BSiDnOyx9OS5arv\r\n";
//        private readonly string tenantId = "8f7ac903-673a-4e39-abd3-4884917219a4";
//        private readonly string workspaceId = "fd957e0b-0766-48c0-a83d-896aa1bb36b0";
//        private readonly string reportId = "c3e6f075a43e556a479f";

//        [HttpGet("embed-info")]
//        public async Task<IActionResult> GetEmbedInfo()
//        {
//            var authorityUrl = $"https://login.microsoftonline.com/{tenantId}";
//            var scopes = new[] { "https://analysis.windows.net/powerbi/api/.default" };

//            var confidentialClient = ConfidentialClientApplicationBuilder
//                .Create(clientId)
//                .WithClientSecret(clientSecret)
//                .WithAuthority(new Uri(authorityUrl))
//                .Build();

//            var authResult = await confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync();

//            using var powerBiClient = new PowerBIClient(new Uri("https://api.powerbi.com/"), new TokenCredentials(authResult.AccessToken, "Bearer"));
//            Guid workspaceGuid = Guid.Parse(workspaceId);
//            Guid reportGuid = Guid.Parse(reportId);
          
//            var report = await powerBiClient.Reports.GetReportInGroupAsync(workspaceGuid, reportGuid);
//            string DataSetId =  report.DatasetId;
//            //var embedToken = await powerBiClient.EmbedToken.GenerateTokenAsync(new GenerateTokenRequest(
//            // accessLevel: "view",
//            // datasetId: "12121212121212121" ));

//            //var embedToken = await powerBiClient.Reports.GenerateTokenInGroup(workspaceId, reportId,
//                          new GenerateTokenRequest(accessLevel: "View", datasetId: DataSetId.ToString()));

//            var embedToken = await powerBiClient.Reports.GenerateTokenInGroup(workspaceId, reportId,
//                           new GenerateTokenRequest(accessLevel: "View", datasetId: DataSetId.ToString()));

//            return Ok(new
//            {
//                EmbedUrl = report.EmbedUrl,
//                EmbedToken = embedToken.Token
//            });
//        }
//    }
//}
