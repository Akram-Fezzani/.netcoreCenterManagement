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
using System.Linq;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectorController : ControllerBase
    {

        public IGenericRepository<Collector> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public CollectorController(IGenericRepository<Collector> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetCollecteurs")]
        public IEnumerable<Collector> getAllCollecteurs()
        {
            return (new GetListGenericHandler<Collector>(Repository).Handle(new GetListGenericQuery<Collector>(null, null), cancellation).Result);
        }




        [HttpGet("GetCollecteur")]
        public Collector getCollecteurById(Guid Id)
        {
            return (new GetGenericHandler<Collector>(Repository).Handle(new GetGenericQuery<Collector>(condition: x => x.CollecteurId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutCollecteur")]
        public async Task<Collector> PostCollecteur([FromBody] Collector Collecteur)
        {
            var x = new AddGenericCommand<Collector>(Collecteur);
            var GenericHandler = new AddGenericHandler<Collector>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateCollecteur")]
        public async Task<Collector> PutCollecteur([FromBody] Collector Collecteur)
        {
            var x = new PutGenericCommand<Collector>(Collecteur);
            var GenericHandler = new PutGenericHandler<Collector>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteCollecteur")]
        public async Task<Collector> DeleteCollecteur(Guid Id)
        {
            var x = new RemoveGenericCommand<Collector>(Id);
            var GenericHandler = new RemoveGenericHandler<Collector>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }


        [HttpGet("GetNumberOfCollectorss")]
        public int GetNumberOfUsers()
        {
            IEnumerable<Collector> users = (new GetListGenericHandler<Collector>(Repository).Handle(new GetListGenericQuery<Collector>(null, null), cancellation).Result);
            return users.Count();
        }

        [HttpGet("GetNumberOfCollectorsByCenter")]
        public int GetNumberOfCollectorsByCenter(Guid id)
        {
            var x = 0;
            IEnumerable<Collector> Collectors = (new GetListGenericHandler<Collector>(Repository).Handle(new GetListGenericQuery<Collector>(null, null), cancellation).Result);
            foreach (var Collector in Collectors)
            {
                if (Collector.CenterId ==id)
                {
                    if(Collector.state== true)
                    {
                         x= x + 1;
                    }
                    
                }
            }
            return (x);
        }


        [HttpGet("GetCollectorsByCenterId")]
        public IEnumerable<Collector> GetCollectorsByCenterId(Guid IdCenter)
        {
            List<Collector> list = new List<Collector>();

            IEnumerable<Collector> Collectors = (new GetListGenericHandler<Collector>(Repository).Handle(new GetListGenericQuery<Collector>(null, null), cancellation).Result);

            foreach (var c in Collectors)
            {
                if (IdCenter == c.CenterId)
                {
                    list.Add(c);
                }
            }

            IEnumerable<Collector> BuildingsByCenter = list;
            return BuildingsByCenter;
        }

    }
}
