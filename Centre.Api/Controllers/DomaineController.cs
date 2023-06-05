using AutoMapper;
using Centre.Domain.Models;
using Centre.Domain.Commands;
using Centre.Domain.Handlers;
using Centre.Domain.Interfaces;
using Centre.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Centre.Domain.Models;

namespace Societe.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomaineController : ControllerBase
    {
        public IGenericRepository<Domaines> Repository;
        public IGenericRepository<Society> insrepository;
       


        CancellationToken cancellation;
        private readonly IMapper _mapper;


        public DomaineController(IGenericRepository<Domaines> _Repository,  IGenericRepository<Society> _insrepository, IMapper mapper)
        {
            Repository = _Repository;
            insrepository = _insrepository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

      



        [HttpGet("GetDomaines")]
        public IEnumerable<Domaines> getAllDomaines()
        {
            return (new GetListGenericHandler<Domaines>(Repository).Handle(new GetListGenericQuery<Domaines>(null, null), cancellation).Result);
        }

        [HttpGet("GetDomaine")]
        public Domaines getDomaineById(Guid Id)
        {
            return (new GetGenericHandler<Domaines>(Repository).Handle(new GetGenericQuery<Domaines>(condition: x => x.DomaineId == Id, null), cancellation).Result);
        }

      

        [HttpPost("AjoutDomaine")]
        public async Task<Domaines> PostDomaine([FromBody] Domaines Domaine)
        {
            var x = new AddGenericCommand<Domaines>(Domaine);
            var GenericHandler = new AddGenericHandler<Domaines>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
        [HttpPut("UpdateDomaine")]
        public async Task<Domaines> PutDomaine( [FromBody] Domaines Domaine)
        {
            var x = new PutGenericCommand<Domaines>(Domaine);
            var GenericHandler = new PutGenericHandler<Domaines>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }

        [HttpDelete("DeleteDomaine")]
        public async Task<Domaines> DeleteDomaine(Guid Id)
        {
            var x = new RemoveGenericCommand<Domaines>(Id);
            var GenericHandler = new RemoveGenericHandler<Domaines>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }



      
    }
}
