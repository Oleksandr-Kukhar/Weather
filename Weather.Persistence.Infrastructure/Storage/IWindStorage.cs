﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Persistence.Model;

namespace Weather.Persistence.Infrastructure.Storage
{
    public interface IWindStorage
    {
        Task<Wind> GetLastValueAsync();
        Task<Wind> GetMaxValueAsync(DateTime date);
        Task<Wind> GetMinValueAsync(DateTime date);
    }
}
