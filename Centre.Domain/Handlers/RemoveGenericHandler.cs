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
    public class RemoveGenericHandler<TEntity> : IRequestHandler<RemoveGenericCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;

        public RemoveGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(RemoveGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Delete(request.Id);
            return Task.FromResult(result);
        }
    }
}
