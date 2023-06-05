using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public class SocietyCenterController : ControllerBase
    {



        public IGenericRepository<SocietyCenter> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public SocietyCenterController(IGenericRepository<SocietyCenter> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetSocietyCenters")]
        public IEnumerable<SocietyCenter> getAllSocietyCenters()
        {
            return (new GetListGenericHandler<SocietyCenter>(Repository).Handle(new GetListGenericQuery<SocietyCenter>(null, null), cancellation).Result);
        }




        [HttpGet("GetSocietyCenter")]
        public SocietyCenter getSocietyCenterById(Guid Id)
        {
            return (new GetGenericHandler<SocietyCenter>(Repository).Handle(new GetGenericQuery<SocietyCenter>(condition: x => x.SocietyCenterId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutSocietyCenter")]
        public async Task<SocietyCenter> PostSocietyCenter([FromBody] SocietyCenter SocietyCenter)
        {
            var x = new AddGenericCommand<SocietyCenter>(SocietyCenter);
            var GenericHandler = new AddGenericHandler<SocietyCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateSocietyCenter")]
        public async Task<SocietyCenter> PutSocietyCenter([FromBody] SocietyCenter SocietyCenter)
        {
            var x = new PutGenericCommand<SocietyCenter>(SocietyCenter);
            var GenericHandler = new PutGenericHandler<SocietyCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteSocietyCenter")]
        public async Task<SocietyCenter> DeleteSocietyCenter(Guid Id)
        {
            var x = new RemoveGenericCommand<SocietyCenter>(Id);
            var GenericHandler = new RemoveGenericHandler<SocietyCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
