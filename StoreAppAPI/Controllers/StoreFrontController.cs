using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAppBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {

        private iStoreFrontBL _storefrontBL;

        public StoreFrontController(iStoreFrontBL p_storefrontBl)
        {
            _storefrontBL = p_storefrontBl;
        }

        [HttpGet("/ViewStoreInventory")]
        public IActionResult ViewStoreInventory([FromQuery] int p_storeId)
        {
            return Ok(_storefrontBL.ViewStoreInventory(p_storeId));
        }

    }
}