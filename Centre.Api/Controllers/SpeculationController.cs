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
    public class SpeculationController : ControllerBase
    {



        public IGenericRepository<Speculation> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public SpeculationController(IGenericRepository<Speculation> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetSpeculations")]
        public IEnumerable<Speculation> getAllSpeculations()
        {
            return (new GetListGenericHandler<Speculation>(Repository).Handle(new GetListGenericQuery<Speculation>(null, null), cancellation).Result);
        }




        [HttpGet("GetSpeculation")]
        public Speculation getSpeculationById(Guid Id)
        {
            return (new GetGenericHandler<Speculation>(Repository).Handle(new GetGenericQuery<Speculation>(condition: x => x.SpeculationId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutSpeculation")]
        public async Task<Speculation> PostSpeculation([FromBody] Speculation Speculation)
        {
            var x = new AddGenericCommand<Speculation>(Speculation);
            var GenericHandler = new AddGenericHandler<Speculation>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateSpeculation")]
        public async Task<Speculation> PutSpeculation([FromBody] Speculation Speculation)
        {
            var x = new PutGenericCommand<Speculation>(Speculation);
            var GenericHandler = new PutGenericHandler<Speculation>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteSpeculation")]
        public async Task<Speculation> DeleteSpeculation(Guid Id)
        {
            var x = new RemoveGenericCommand<Speculation>(Id);
            var GenericHandler = new RemoveGenericHandler<Speculation>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
