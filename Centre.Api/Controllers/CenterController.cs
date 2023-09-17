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

namespace Centre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        public IGenericRepository<Center> Repository;
        public IGenericRepository<Building> BuildingRepository;
        public IGenericRepository<DemandeVeto> DemandeVetoRepository;

        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public CenterController(IGenericRepository<Center> _Repository, IGenericRepository<DemandeVeto> _DemandeVetoRepository, IGenericRepository<Building> _BuildingRepository, IMapper mapper)
        {
            Repository = _Repository;
            BuildingRepository = _BuildingRepository;
            DemandeVetoRepository = _DemandeVetoRepository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetCentres")]
        public IEnumerable<Center> getAllCentres()
        {
            return (new GetListGenericHandler<Center>(Repository).Handle(new GetListGenericQuery<Center>(null, null), cancellation).Result);
        }




        [HttpGet("GetCentre")]
        public Center getCentreById(Guid Id)
        {
            return (new GetGenericHandler<Center>(Repository).Handle(new GetGenericQuery<Center>(condition: x => x.CenterId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutCentre")]
        public async Task<Center> PostCentre([FromBody] Center Centre)
        {
            var x = new AddGenericCommand<Center>(Centre);
            var GenericHandler = new AddGenericHandler<Center>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateCentre")]
        public async Task<Center> PutCentre([FromBody] Center Centre)
        {
            var x = new PutGenericCommand<Center>(Centre);
            var GenericHandler = new PutGenericHandler<Center>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteCentre")]
        public async Task<Center> DeleteCentre(Guid Id)
        {
            var x = new RemoveGenericCommand<Center>(Id);
            var GenericHandler = new RemoveGenericHandler<Center>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }

        [HttpGet("GetBuildingsByCenterId")]
        public IEnumerable<Building> GetBuildingsByCenterId(Guid IdCenter)
        {
            List<Building> list = new List<Building>();

            IEnumerable<Building> Buildings = (new GetListGenericHandler<Building>(BuildingRepository).Handle(new GetListGenericQuery<Building>(null, null), cancellation).Result);

                foreach (var b in Buildings)
                {
                    if (IdCenter == b.CenterId)
                    {
                        list.Add(b);
                    }
                }
            
            IEnumerable<Building> BuildingsByCenter = list;
            return BuildingsByCenter;
        }

        [HttpGet("GetDemandeVetoByCenterId")]

        public IEnumerable<DemandeVeto> GetDemandeVetoByCenterId(Guid IdCenter)
        {
            List<DemandeVeto> list = new List<DemandeVeto>();

            IEnumerable<Building> Buildings = GetBuildingsByCenterId(IdCenter);
            IEnumerable<DemandeVeto> DemandeVetos = (new GetListGenericHandler<DemandeVeto>(DemandeVetoRepository).Handle(new GetListGenericQuery<DemandeVeto>(null, null), cancellation).Result);

            foreach (var b in Buildings)
            {
                foreach (var d in DemandeVetos)
                {
                    if (b.BuildingId == d.BuildingId)
                    {
                        list.Add(d);
                    }
                }
            }
            IEnumerable<DemandeVeto> DemandeVetoByAntenna = list;
            return DemandeVetoByAntenna;
        }
    }
}
