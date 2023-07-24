using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Centre.Domain.Interfaces;
using System.Text;
using Centre.Domain.Models;
using Centre.Domain.Queries;
using Centre.Domain.Commands;
using Centre.Domain.Handlers;
using Centre.Data.Repositories;

namespace Centre.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Repository
            services.AddTransient<IGenericRepository<ChefCenter>, GenericRepository<ChefCenter>>();
            services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
            services.AddTransient<IGenericRepository<Antenna>, GenericRepository<Antenna>>();
            services.AddTransient<IGenericRepository<Building>, GenericRepository<Building>>();
            services.AddTransient<IGenericRepository<Center>, GenericRepository<Center>>();
            services.AddTransient<IGenericRepository<Collector>, GenericRepository<Collector>>();
            services.AddTransient<IGenericRepository<Domaines>, GenericRepository<Domaines>>();
            services.AddTransient<IGenericRepository<Society>, GenericRepository<Society>>();
            services.AddTransient<IGenericRepository<Speculation>, GenericRepository<Speculation>>();
            services.AddTransient<IGenericRepository<Domain.Models.Type>, GenericRepository<Domain.Models.Type>>();
            services.AddTransient<IGenericRepository<FicheMedicale>, GenericRepository<FicheMedicale>>();
            services.AddTransient<IGenericRepository<DemandeVeto>, GenericRepository<DemandeVeto>>();
            services.AddTransient<IGenericRepository<Veterinaire>, GenericRepository<Veterinaire>>();




            services.AddTransient<IRequestHandler<GetListGenericQuery<ChefCenter>, IEnumerable<ChefCenter>>, GetListGenericHandler<ChefCenter>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<ChefCenter>, ChefCenter>, GetGenericHandler<ChefCenter>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<ChefCenter>, ChefCenter>, PutGenericHandler<ChefCenter>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<ChefCenter>, ChefCenter>, RemoveGenericHandler<ChefCenter>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<ChefCenter>, ChefCenter>, AddGenericHandler<ChefCenter>>();




            services.AddTransient<IRequestHandler<GetListGenericQuery<User>, IEnumerable<User>>, GetListGenericHandler<User>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<User>, User>, GetGenericHandler<User>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<User>, User>, PutGenericHandler<User>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<User>, User>, RemoveGenericHandler<User>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<User>, User>, AddGenericHandler<User>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Antenna>, IEnumerable<Antenna>>, GetListGenericHandler<Antenna>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Antenna>, Antenna>, GetGenericHandler<Antenna>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Antenna>, Antenna>, PutGenericHandler<Antenna>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Antenna>, Antenna>, RemoveGenericHandler<Antenna>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Antenna>, Antenna>, AddGenericHandler<Antenna>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Building>, IEnumerable<Building>>, GetListGenericHandler<Building>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Building>, Building>, GetGenericHandler<Building>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Building>, Building>, PutGenericHandler<Building>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Building>, Building>, RemoveGenericHandler<Building>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Center>, IEnumerable<Center>>, GetListGenericHandler<Center>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Center>, Center>, GetGenericHandler<Center>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Center>, Center>, PutGenericHandler<Center>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Center>, Center>, RemoveGenericHandler<Center>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Collector>, IEnumerable<Collector>>, GetListGenericHandler<Collector>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Collector>, Collector>, GetGenericHandler<Collector>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Collector>, Collector>, PutGenericHandler<Collector>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Collector>, Collector>, RemoveGenericHandler<Collector>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Collector>, Collector>, AddGenericHandler<Collector>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Domaines>, IEnumerable<Domaines>>, GetListGenericHandler<Domaines>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Domaines>, Domaines>, GetGenericHandler<Domaines>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Domaines>, Domaines>, PutGenericHandler<Domaines>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Domaines>, Domaines>, RemoveGenericHandler<Domaines>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Domaines>, Domaines>, AddGenericHandler<Domaines>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Society>, IEnumerable<Society>>, GetListGenericHandler<Society>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Society>, Society>, GetGenericHandler<Society>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Society>, Society>, PutGenericHandler<Society>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Society>, Society>, RemoveGenericHandler<Society>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Society>, Society>, AddGenericHandler<Society>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Speculation>, IEnumerable<Speculation>>, GetListGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Speculation>, Speculation>, GetGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Speculation>, Speculation>, PutGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Speculation>, Speculation>, RemoveGenericHandler<Speculation>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Speculation>, Speculation>, AddGenericHandler<Speculation>>();

            services.AddTransient<IRequestHandler<GetListGenericQuery<Domain.Models.Type>, IEnumerable<Domain.Models.Type>>, GetListGenericHandler<Domain.Models.Type>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Domain.Models.Type>, Domain.Models.Type>, GetGenericHandler<Domain.Models.Type>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Domain.Models.Type>, Domain.Models.Type>, PutGenericHandler<Domain.Models.Type>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Domain.Models.Type>, Domain.Models.Type>, RemoveGenericHandler<Domain.Models.Type>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Domain.Models.Type>, Domain.Models.Type>, AddGenericHandler<Domain.Models.Type>>();
        }
    }
}
