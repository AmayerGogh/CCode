using Microsoft.AspNetCore.Antiforgery;
using CCode.Controllers;

namespace CCode.Web.Host.Controllers
{
    public class AntiForgeryController : CCodeControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
