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
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Centre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefCenterController : ControllerBase
    {
        public IGenericRepository<ChefCenter> Repository;
        public IGenericRepository<User> UserRepository;
        User chefs = new User();
        CancellationToken cancellation;
        private readonly IMapper _mapper;
        HttpClientHandler _clientHandler = new HttpClientHandler();


        public ChefCenterController(IGenericRepository<ChefCenter> _Repository, IGenericRepository<User> _UserRepository, IMapper mapper)
        {
            Repository = _Repository;
            UserRepository = _UserRepository;

            cancellation = new CancellationToken();
            _mapper = mapper;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }

        [HttpGet("GetChefCenters")]
        public IEnumerable<ChefCenter> getAllChefCenters()
        {
            return (new GetListGenericHandler<ChefCenter>(Repository).Handle(new GetListGenericQuery<ChefCenter>(null, null), cancellation).Result);
        }




        [HttpGet("GetChefCenter")]
        public ChefCenter getChefCenterById(Guid Id)
        {
            return (new GetGenericHandler<ChefCenter>(Repository).Handle(new GetGenericQuery<ChefCenter>(condition: x => x.ChefCenterId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutChefCenter")]
        public async Task<ChefCenter> PostCentre([FromBody] ChefCenter ChefCenter)
        {

            var x = new AddGenericCommand<ChefCenter>(ChefCenter);
            var GenericHandler = new AddGenericHandler<ChefCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateCentre")]
        public async Task<ChefCenter> PutCentre([FromBody] ChefCenter ChefCenter)
        {
            var x = new PutGenericCommand<ChefCenter>(ChefCenter);
            var GenericHandler = new PutGenericHandler<ChefCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteCentre")]
        public async Task<ChefCenter> DeleteCentre(Guid Id)
        {
            var x = new RemoveGenericCommand<ChefCenter>(Id);
            var GenericHandler = new RemoveGenericHandler<ChefCenter>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }






        [HttpGet("GetChefsCenters")]
        public async Task<List<User>> GetAllChesfCenters()
        {
           var  Chefs = new List<User>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using( var response=await httpClient.GetAsync ("https://localhost:44317/api/ChefCenter/GetChefs"))
                {
                    string apiResonse = await response.Content.ReadAsStringAsync();
                    Chefs = JsonConvert.DeserializeObject<List<User>>(apiResonse);
                }
            }
            return Chefs;
        }


        [HttpGet("GetUserById")]
        public async Task<User> GetAllChefCenter( Guid Id)
        {
            var Chefs = new User();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44317/api/ChefCenter/GetChef?Id=" + Id))
                {
                    string apiResonse = await response.Content.ReadAsStringAsync();
                    Chefs = JsonConvert.DeserializeObject<User>(apiResonse);
                }
            }
            return Chefs;
        }

    
        
        [HttpPost("AffectCenterToUser")]
        public async Task<String> AffectCenterToUsers(Guid CenterId, Guid ChefCenterId)
        {
            String message = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {
            
                using (var response = await httpClient.PostAsync("https://localhost:44317/api/ChefCenter/AffectChefToCenter?ChefCenterId=" + ChefCenterId + "&CenterId=" + CenterId))
                {
                    message = await response.Content.ReadAsStringAsync();

                }
            }
            return message;
        }



    }
}
