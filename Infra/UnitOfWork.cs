﻿using Domain.Abstractions;

namespace Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConnectionContext _connectionContext;

        public UnitOfWork(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        public async Task Commit()
        { 
            await _connectionContext.SaveChangesAsync();
        }
    }
}
