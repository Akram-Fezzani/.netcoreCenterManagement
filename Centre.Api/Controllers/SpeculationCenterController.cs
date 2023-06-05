using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Centre.Data.Context;
using Centre.Domain.Models;
using Centre.Domain.Interfaces;
using AutoMapper;
using System.Threading;
using Centre.Domain.Handlers;
using Centre.Domain.Queries;
using Centre.Domain.Commands;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeculationCenterController : ControllerBase
    {



        public IGenericRepository<SpeculationCenter> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public SpeculationCenterController(IGenericRepository<SpeculationCenter> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetSpeculationCenters")]
        public IEnumerable<SpeculationCenter> getAllSpeculationCenters()
        {
            return (new GetListGenericHandler<SpeculationCenter>(Repository).Handle(new GetListGenericQuery<SpeculationCenter>(null, null), cancellation).Result);
        }




        [HttpGet("GetSpeculationCenter")]
        public SpeculationCenter getSpeculationCenterById(Guid Id)
        {
            return (new GetGenericHandler<SpeculationCenter>(Repository).Handle(new GetGenericQuery<SpeculationCenter>(condition: x => x.SpeculationCenterId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutSpeculationCenter")]
        public async Task<SpeculationCenter> PostSpeculationCenter([FromBody] SpeculationCenter SpeculationCenter)
        {
            var x = new AddGenericCommand<SpeculationCenter>(SpeculationCenter);
            var GenericHandler = new AddGenericHandler<SpeculationCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateSpeculationCenter")]
        public async Task<SpeculationCenter> PutSpeculationCenter([FromBody] SpeculationCenter SpeculationCenter)
        {
            var x = new PutGenericCommand<SpeculationCenter>(SpeculationCenter);
            var GenericHandler = new PutGenericHandler<SpeculationCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteSpeculationCenter")]
        public async Task<SpeculationCenter> DeleteSpeculationCenter(Guid Id)
        {
            var x = new RemoveGenericCommand<SpeculationCenter>(Id);
            var GenericHandler = new RemoveGenericHandler<SpeculationCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
