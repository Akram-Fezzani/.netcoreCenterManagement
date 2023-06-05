using Centre.Domain.Commands;
using Centre.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centre.Domain.Handlers
{
    public class PutGenericHandler<TEntity> : IRequestHandler<PutGenericCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;

        public PutGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(PutGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Update(request.Entity);
            return Task.FromResult(result);
        }
    }
}
