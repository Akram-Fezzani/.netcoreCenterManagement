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
    public class AntennaController : ControllerBase
    {



        public IGenericRepository<Antenna> Repository;
        public IGenericRepository<DemandeVeto> DemandeVetoRepository;
        public IGenericRepository<Center> CenterRepository;
        public IGenericRepository<Building> BuildingRepository;
        public IGenericRepository<Veterinaire> VeterinaireRepository;
        public IGenericRepository<Collector> CollectorRepository;

        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public AntennaController(IGenericRepository<Antenna> _Repository, IGenericRepository<Collector> _CollectorRepository, IGenericRepository<Veterinaire> _VeterinaireRepository, IGenericRepository<Building> _BuildingRepository, IGenericRepository<DemandeVeto> _DemandeVetoRepository, IGenericRepository<Center> _CenterRepository, IMapper mapper)
        {
            Repository = _Repository;
            DemandeVetoRepository = _DemandeVetoRepository;
            CenterRepository = _CenterRepository;
            BuildingRepository = _BuildingRepository;
            VeterinaireRepository = _VeterinaireRepository;
            CollectorRepository = _CollectorRepository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("Get Antennas")]
        public IEnumerable<Antenna> getAllAntennas()
        {
            return (new GetListGenericHandler<Antenna>(Repository).Handle(new GetListGenericQuery<Antenna>(null, null), cancellation).Result);
        }




        [HttpGet("GetAntenna")]
        public Antenna getAntennaById(Guid Id)
        {
            return (new GetGenericHandler<Antenna>(Repository).Handle(new GetGenericQuery<Antenna>(condition: x => x.AntennaId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutAntenna")]
        public async Task<Antenna> PostAntenna([FromBody] Antenna Antenna)
        {
            var x = new AddGenericCommand<Antenna>(Antenna);
            var GenericHandler = new AddGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateAntenna")]
        public async Task<Antenna> PutAntenna([FromBody] Antenna Antenna)
        {
            var x = new PutGenericCommand<Antenna>(Antenna);
            var GenericHandler = new PutGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteAntenna")]
        public async Task<Antenna> DeleteAntenna(Guid Id)
        {
            var x = new RemoveGenericCommand<Antenna>(Id);
            var GenericHandler = new RemoveGenericHandler<Antenna>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }

        [HttpGet("GetDemandeByAntennaId")]
        public IEnumerable<DemandeVeto> GetDemandeByAntennaId(Guid IdAntenna, Guid CenterId)
        {
            List<DemandeVeto> list = new List<DemandeVeto>();

            IEnumerable<DemandeVeto> DemandeVetos = new GetListGenericHandler<DemandeVeto>(DemandeVetoRepository).Handle(new GetListGenericQuery<DemandeVeto>(null, null), cancellation).Result;
            var center = (new GetGenericHandler<Center>(CenterRepository).Handle(new GetGenericQuery<Center>(condition: x => x.CenterId == CenterId, null), cancellation).Result);

            foreach (var b in DemandeVetos)
            {
                //var BuildingId = b.BuildingId;
              // var building = (new GetGenericHandler<Building>(BuildingRepository).Handle(new GetGenericQuery<Building>(condition: x => x.BuildingId == BuildingId, null), cancellation).Result);
              //  var CenterId = building.CenterId;

                if (center.AntennaId == IdAntenna)
                {
                    list.Add(b);
                }
            }
            IEnumerable<DemandeVeto> DemandeVetoByAntenna = list;
            return DemandeVetoByAntenna;
        }

        [HttpGet("GetCentersByAntennaId")]
        public IEnumerable<Center> GetCentersByAntennaId(Guid IdAntenna)
        {
            List<Center> list = new List<Center>();

            IEnumerable<Center> Centers = new GetListGenericHandler<Center>(CenterRepository).Handle(new GetListGenericQuery<Center>(null, null), cancellation).Result;

            foreach (var c in Centers)
            {
               
                if (c.AntennaId == IdAntenna)
                {
                    list.Add(c);
                }
            }
            IEnumerable<Center> CentersByAntenna = list;
            return CentersByAntenna;
        }



        [HttpGet("GetBuildingsByAntennaId")]
        public IEnumerable<Building> GetBuildingsByAntennaId(Guid IdAntenna)
        {
            List<Building> list = new List<Building>();

            IEnumerable<Center> Centers = GetCentersByAntennaId( IdAntenna);
            IEnumerable<Building> Buildings = (new GetListGenericHandler<Building>(BuildingRepository).Handle(new GetListGenericQuery<Building>(null, null), cancellation).Result);

            foreach (var c in Centers)
            {
                foreach (var b in Buildings)
                {
                    if (c.CenterId == b.CenterId)
                    {
                        list.Add(b);
                    }
                }
            }
            IEnumerable<Building> BuildingsByAntenna = list;
            return BuildingsByAntenna;
        }


        [HttpGet("GetDemandeVetoByAntennaId")]
        public IEnumerable<DemandeVeto> GetDemandeVetoByAntennaId(Guid IdAntenna)
        {
            List<DemandeVeto> list = new List<DemandeVeto>();

            IEnumerable<Building> Buildings = GetBuildingsByAntennaId(IdAntenna);
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


        [HttpGet("GetVetoByAntennaId")]
        public IEnumerable<Veterinaire> GetVetoByAntennaId(Guid IdAntenna)
        {
            IEnumerable<Center> Centers = GetCentersByAntennaId(IdAntenna);

            List<Veterinaire> list = new List<Veterinaire>();

            IEnumerable< Veterinaire> Veterinaires = (new GetListGenericHandler<Veterinaire>(VeterinaireRepository).Handle(new GetListGenericQuery<Veterinaire>(null, null), cancellation).Result);

            foreach (var c in Centers)
            {
                foreach (var v in Veterinaires)
                {
                    if (v.CenterId == c.CenterId)
                    {
                        list.Add(v);
                    }
                }
            }
            
            IEnumerable<Veterinaire> DemandeVetoByAntenna = list;
            return DemandeVetoByAntenna;
        }


        [HttpGet("GetBuildingsByCenter")]
        public BuildingByCenter GetBuildingsByCenter(Guid IdAntenna)
        {
            BuildingByCenter bbc = new BuildingByCenter();
            bbc.Centers = new List<String>();
            bbc.Buildings = new List<int>();

            IEnumerable<Building> Buildings = GetBuildingsByAntennaId(IdAntenna);
            IEnumerable<Center> Centers = GetCentersByAntennaId(IdAntenna);
            foreach (var Center in Centers)
            {
                var s = 0;
                bbc.Centers.Add(Center.CenterLabel);
                foreach (var Building in Buildings)
                {
                    if (Center.CenterId == Building.CenterId)
                    {
                        s++;
                    }
                }
                bbc.Buildings.Add(s);
            }
            return bbc;
        }

        [HttpGet("GetCollectorsByAntennaId")]
        public IEnumerable<Collector> GetCollectorsByAntennaId(Guid IdAntenna)
        {
            List<Collector> list = new List<Collector>();
            IEnumerable<Center> Centers = GetCentersByAntennaId(IdAntenna);

            IEnumerable<Collector> Collectors = (new GetListGenericHandler<Collector>(CollectorRepository).Handle(new GetListGenericQuery<Collector>(null, null), cancellation).Result);

            foreach (var center in Centers)
            {
                foreach (var c in Collectors)

                {
                    if (center.CenterId == c.CenterId)
                    {
                        list.Add(c);
                    }
                }
            }

            IEnumerable<Collector> BuildingsByCenter = list;
            return BuildingsByCenter;
        }

        [HttpGet("GetCenterByAntenna")]
        public CenterByAntenna GetCenterByAntenna()
        {
            CenterByAntenna cba = new CenterByAntenna();
            cba.Antennas = new List<String>();
            cba.Centers = new List<int>();

             

            IEnumerable<Antenna> Antennas = (new GetListGenericHandler<Antenna>(Repository).Handle(new GetListGenericQuery<Antenna>(null, null), cancellation).Result);
            IEnumerable<Center> Centers = (new GetListGenericHandler<Center>(CenterRepository).Handle(new GetListGenericQuery<Center>(null, null), cancellation).Result);
            foreach (var a in Antennas)
            {
                var s = 0;
                cba.Antennas.Add(a.AntennaLabel);
                foreach (var c in Centers)
                {
                    if (a.AntennaId == c.AntennaId)
                    {
                        s++;
                    }
                }
                cba.Centers.Add(s);
            }
            return cba;
        }

    }
}
