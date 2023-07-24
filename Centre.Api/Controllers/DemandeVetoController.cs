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
    public class DemandeVetoController : ControllerBase
    {



        public IGenericRepository<DemandeVeto> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public DemandeVetoController(IGenericRepository<DemandeVeto> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("Get DemandeVetos")]
        public IEnumerable<DemandeVeto> getAllDemandeVetos()
        {
            return (new GetListGenericHandler<DemandeVeto>(Repository).Handle(new GetListGenericQuery<DemandeVeto>(null, null), cancellation).Result);
        }




        [HttpGet("GetDemandeVeto")]
        public DemandeVeto getDemandeVetoById(Guid Id)
        {
            return (new GetGenericHandler<DemandeVeto>(Repository).Handle(new GetGenericQuery<DemandeVeto>(condition: x => x.DemandeVetoId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutDemandeVeto")]
        public async Task<DemandeVeto> PostDemandeVeto([FromBody] DemandeVeto DemandeVeto)
        {
            var x = new AddGenericCommand<DemandeVeto>(DemandeVeto);
            var GenericHandler = new AddGenericHandler<DemandeVeto>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateDemandeVeto")]
        public async Task<DemandeVeto> PutDemandeVeto([FromBody] DemandeVeto DemandeVeto)
        {
            var x = new PutGenericCommand<DemandeVeto>(DemandeVeto);
            var GenericHandler = new PutGenericHandler<DemandeVeto>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteDemandeVeto")]
        public async Task<DemandeVeto> DeleteDemandeVeto(Guid Id)
        {
            var x = new RemoveGenericCommand<DemandeVeto>(Id);
            var GenericHandler = new RemoveGenericHandler<DemandeVeto>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
