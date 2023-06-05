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
    public class AntennaController : ControllerBase
    {



        public IGenericRepository<Antenna> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public AntennaController(IGenericRepository<Antenna> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("Get Antennas")]
        public IEnumerable<Antenna> getAllAntennas()
        {
            return (new GetListGenericHandler<Antenna>(Repository).Handle(new GetListGenericQuery<Antenna>(null, null), cancellation).Result);
        }




        [HttpGet("GetAntenna")]
        public Antenna getAntennaById(Guid Id)
        {
            return (new GetGenericHandler<Antenna>(Repository).Handle(new GetGenericQuery<Antenna>(condition: x => x.AntennaId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutAntenna")]
        public async Task<Antenna> PostAntenna([FromBody] Antenna Antenna)
        {
            var x = new AddGenericCommand<Antenna>(Antenna);
            var GenericHandler = new AddGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateAntenna")]
        public async Task<Antenna> PutAntenna([FromBody] Antenna Antenna)
        {
            var x = new PutGenericCommand<Antenna>(Antenna);
            var GenericHandler = new PutGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteAntenna")]
        public async Task<Antenna> DeleteAntenna(Guid Id)
        {
            var x = new RemoveGenericCommand<Antenna>(Id);
            var GenericHandler = new RemoveGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
