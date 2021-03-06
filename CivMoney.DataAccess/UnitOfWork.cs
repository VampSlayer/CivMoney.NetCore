﻿using CivMoney.DataAccess.Contracts;
using CivMoney.DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace CivMoney.DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool _disposed = false;

        private readonly ApplicationDbContext _context;

        private GenericRepository<Transaction> _transactions;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Transaction> TransactionsRepository => _transactions ??= new GenericRepository<Transaction>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
