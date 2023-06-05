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
using Type = Centre.Domain.Models.Type;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {



        public IGenericRepository<Type> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public TypeController(IGenericRepository<Type> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetTypes")]
        public IEnumerable<Type> getAllTypes()
        {
            return (new GetListGenericHandler<Type>(Repository).Handle(new GetListGenericQuery<Type>(null, null), cancellation).Result);
        }




        [HttpGet("GetType")]
        public Type getTypeById(Guid Id)
        {
            return (new GetGenericHandler<Type>(Repository).Handle(new GetGenericQuery<Type>(condition: x => x.TypeId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutType")]
        public async Task<Type> PostType([FromBody] Type Type)
        {
            var x = new AddGenericCommand<Type>(Type);
            var GenericHandler = new AddGenericHandler<Type>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateType")]
        public async Task<Type> PutType([FromBody] Type Type)
        {
            var x = new PutGenericCommand<Type>(Type);
            var GenericHandler = new PutGenericHandler<Type>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteType")]
        public async Task<Type> DeleteType(Guid Id)
        {
            var x = new RemoveGenericCommand<Type>(Id);
            var GenericHandler = new RemoveGenericHandler<Type>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
