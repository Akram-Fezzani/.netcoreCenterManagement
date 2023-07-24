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
    public class VeterinaireController : ControllerBase
    {



        public IGenericRepository<Veterinaire> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public VeterinaireController(IGenericRepository<Veterinaire> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("Get Veterinaires")]
        public IEnumerable<Veterinaire> getAllVeterinaires()
        {
            return (new GetListGenericHandler<Veterinaire>(Repository).Handle(new GetListGenericQuery<Veterinaire>(null, null), cancellation).Result);
        }




        [HttpGet("GetVeterinaire")]
        public Veterinaire getVeterinaireById(Guid Id)
        {
            return (new GetGenericHandler<Veterinaire>(Repository).Handle(new GetGenericQuery<Veterinaire>(condition: x => x.VeterinaireId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutVeterinaire")]
        public async Task<Veterinaire> PostVeterinaire([FromBody] Veterinaire Veterinaire)
        {
            var x = new AddGenericCommand<Veterinaire>(Veterinaire);
            var GenericHandler = new AddGenericHandler<Veterinaire>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateVeterinaire")]
        public async Task<Veterinaire> PutVeterinaire([FromBody] Veterinaire Veterinaire)
        {
            var x = new PutGenericCommand<Veterinaire>(Veterinaire);
            var GenericHandler = new PutGenericHandler<Veterinaire>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteVeterinaire")]
        public async Task<Veterinaire> DeleteVeterinaire(Guid Id)
        {
            var x = new RemoveGenericCommand<Veterinaire>(Id);
            var GenericHandler = new RemoveGenericHandler<Veterinaire>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
