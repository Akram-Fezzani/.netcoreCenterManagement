using AutoMapper;
using Centre.Domain.Models;
using Centre.Domain.Commands;
using Centre.Domain.Handlers;
using Centre.Domain.Interfaces;
using Centre.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Centre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        public IGenericRepository<Building> Repository;
       


        CancellationToken cancellation;
        private readonly IMapper _mapper;


        public BuildingController(IGenericRepository<Building> _Repository, IGenericRepository<Domain.Models.Type> _insrepository,   IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

      



        [HttpGet("GetBatiments")]
        public IEnumerable<Building> getAllBatiments()
        {
            return (new GetListGenericHandler<Building>(Repository).Handle(new GetListGenericQuery<Building>(null, null), cancellation).Result);
        }

        [HttpGet("GetBatiment")]
        public Building getBatimentById(Guid Id)
        {
            return (new GetGenericHandler<Building>(Repository).Handle(new GetGenericQuery<Building>(condition: x => x.BuildingId == Id, null), cancellation).Result);
        }

      

        [HttpPost("AjoutBatiment")]
        public async Task<Building> PostBatiment([FromBody] Building Batiment)
        {
            var x = new AddGenericCommand<Building>(Batiment);
            var GenericHandler = new AddGenericHandler<Building>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
        [HttpPut("UpdateBatiment")]
        public async Task<Building> PutBatiment( [FromBody] Building Batiment)
        {
            var x = new PutGenericCommand<Building>(Batiment);
            var GenericHandler = new PutGenericHandler<Building>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }

        [HttpDelete("DeleteBatiment")]
        public async Task<Building> DeleteBatiment(Guid Id)
        {
            var x = new RemoveGenericCommand<Building>(Id);
            var GenericHandler = new RemoveGenericHandler<Building>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }



        
    }
}
