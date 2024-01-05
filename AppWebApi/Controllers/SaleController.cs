using App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _service;

        public SaleController(ISaleAppService service)
        {
            _service = service;
        }
    }
}
