using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions
{
    public interface ITestContext
    {
        DbSet<Test> Tests { get; set; }

        Task SaveChangesAsync();
    }
}
