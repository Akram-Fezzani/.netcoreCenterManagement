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
    public class FicheMedicaleController : ControllerBase
    {



        public IGenericRepository<FicheMedicale> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public FicheMedicaleController(IGenericRepository<FicheMedicale> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetFicheMedicales")]
        public IEnumerable<FicheMedicale> getAllFicheMedicales()
        {
            return (new GetListGenericHandler<FicheMedicale>(Repository).Handle(new GetListGenericQuery<FicheMedicale>(null, null), cancellation).Result);
        }




        [HttpGet("GetFicheMedicale")]
        public FicheMedicale getFicheMedicaleById(Guid Id)
        {
            return (new GetGenericHandler<FicheMedicale>(Repository).Handle(new GetGenericQuery<FicheMedicale>(condition: x => x.FicheMedicaleId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutFicheMedicale")]
        public async Task<FicheMedicale> PostFicheMedicale([FromBody] FicheMedicale FicheMedicale)
        {
            var x = new AddGenericCommand<FicheMedicale>(FicheMedicale);
            var GenericHandler = new AddGenericHandler<FicheMedicale>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateFicheMedicale")]
        public async Task<FicheMedicale> PutFicheMedicale([FromBody] FicheMedicale FicheMedicale)
        {
            var x = new PutGenericCommand<FicheMedicale>(FicheMedicale);
            var GenericHandler = new PutGenericHandler<FicheMedicale>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteFicheMedicale")]
        public async Task<FicheMedicale> DeleteFicheMedicale(Guid Id)
        {
            var x = new RemoveGenericCommand<FicheMedicale>(Id);
            var GenericHandler = new RemoveGenericHandler<FicheMedicale>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
