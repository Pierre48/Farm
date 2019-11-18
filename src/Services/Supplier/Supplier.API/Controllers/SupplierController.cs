using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Supplier.API.Services;
using Supplier.API.Model;

namespace Supplier.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _repository;
        private readonly IIdentityService _identityService;
        private readonly IEventBus _eventBus;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(
            ILogger<SupplierController> logger,
            ISupplierRepository repository,
            IIdentityService identityService,
            IEventBus eventBus)
        {
            _logger = logger;
            _repository = repository;
            _identityService = identityService;
            _eventBus = eventBus;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Model.Supplier), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Supplier>> GetBasketByIdAsync(int id)
        {
            var basket = await _repository.GetSupplierAsync(id);

            return Ok(basket ?? new Model.Supplier(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Model.Supplier), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Model.Supplier>> UpdateBasketAsync([FromBody]Model.Supplier value)
        {
            return Ok(await _repository.UpdateSupplierAsync(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task DeleteSupplierByIdAsync(int id)
        {
            await _repository.DeleteSupplierAsync(id);
        }
    }
}