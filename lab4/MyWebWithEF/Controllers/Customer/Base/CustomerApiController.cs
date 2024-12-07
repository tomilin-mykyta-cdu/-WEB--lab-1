using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebWithEF.Attributes;
using MyWebWithEF.BLL.Enums;

namespace MyWebWithEF.Controllers.Customer.Base
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/customer/api/[controller]")]
    [CustomAuthorize(Roles.Customer)]
    public abstract class CustomerApiController : ControllerBase
    {
    }
}