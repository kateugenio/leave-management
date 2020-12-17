﻿using System;
using leave_management.Data;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<LeaveType> LeaveTypes { get; }

        IGenericRepository<LeaveRequest> LeaveRequests { get; }

        IGenericRepository<LeaveAllocation> LeaveAllocations { get; }

        Task Save();
    }
}
