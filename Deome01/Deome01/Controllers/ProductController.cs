using Demo.Application.Catalog.Productt;
using Demo.ViewMode.Catalog.Productt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IManageProductService _publicProductService;
        private IManageProductService _manaGeProductService;
        public ProductController(IManageProductService publicProductService, IManageProductService manaGeProductService)
        {
            _publicProductService = publicProductService;
            _manaGeProductService = manaGeProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _publicProductService.GetAll();
            return Ok(product);
        }
        [HttpGet("public-pading")]
        public async Task<IActionResult> Get([FromQuery]GetPublicProcductPagingRequest request )
        {
            var product = await _publicProductService.GetAllByCategoryId(request);
            return Ok(product);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var product = await _manaGeProductService.GetById(productId);
            if(product == null)
            {
                return BadRequest("Cannot find Product");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Creact([FromBody]ProductCraectRequest request)
        {
            var productId = await _manaGeProductService.Creact(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product= await _manaGeProductService.GetById(productId);
            return CreatedAtAction(nameof(GetById), new {id=productId},productId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
        {
            var affectedResult = await _manaGeProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
            
        }
        [HttpPut("Price/{Id}/{NewPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int Id, decimal newPrice)
        {
            var IsSuccessfult = await _manaGeProductService.UpdatePrice(Id,newPrice);
            if (IsSuccessfult )
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Dalete(int Id)
        {
            var affectedResult = await _manaGeProductService.Delete(Id);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();

        }

    }
}
