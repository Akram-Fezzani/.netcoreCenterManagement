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

namespace Societe.Api

{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {



        public IGenericRepository<Society> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public SocietyController(IGenericRepository<Society> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetSocietes")]
        public IEnumerable<Society> getAllSocietes()
        {
            return (new GetListGenericHandler<Society>(Repository).Handle(new GetListGenericQuery<Society>(null, null), cancellation).Result);
        }




        [HttpGet("GetSociete")]
        public Society getSocieteById(Guid Id)
        {
            return (new GetGenericHandler<Society>(Repository).Handle(new GetGenericQuery<Society>(condition: x => x.SocietyId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutSociete")]
        public async Task<Society> PostSociete([FromBody] Society Societe)
        {
            var x = new AddGenericCommand<Society>(Societe);
            var GenericHandler = new AddGenericHandler<Society>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateSociete")]
        public async Task<Society> PutSociete([FromBody] Society Societe)
        {
            var x = new PutGenericCommand<Society>(Societe);
            var GenericHandler = new PutGenericHandler<Society>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteSociete")]
        public async Task<Society> DeleteSociete(Guid Id)
        {
            var x = new RemoveGenericCommand<Society>(Id);
            var GenericHandler = new RemoveGenericHandler<Society>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
