using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WMI_NetCore_API.Core;
using WMI_NetCore_API.Extensions;
using WMI_NetCore_API.Controllers.Resources;
using WMI_NetCore_API.Core.Models;
using System.Threading;

namespace WMI_NetCore_API.Controllers
{
    [ApiController]
    [Route("api/wmi")]
    public class WMIController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWMIRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public WMIController(IMapper mapper, IWMIRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("getCountries")]
        public async Task<List<string>> getCountries()
        {
            Thread.Sleep(2000);
            var queryResult = await repository.GetCountries();
            return queryResult;
        }
        [HttpGet]
        [Route("search")]
        public async Task<QueryResultResource<WMIResource>> Get([FromQuery] string filter, [FromQuery] string country)
        {
            Thread.Sleep(2000);
            var queryResult = await repository.GetFilterdWMI(filter, country);
            return mapper.Map<QueryResult<WMIModel>, QueryResultResource<WMIResource>>(queryResult);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<QueryResultResource<WMIResource>> GetAll()
        {
            Thread.Sleep(2000);
            var queryResult = await repository.GetAllWMI();
            return mapper.Map<QueryResult<WMIModel>, QueryResultResource<WMIResource>>(queryResult);
        }

    }

}