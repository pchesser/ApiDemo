using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstractions
{
    public interface ITestContext
    {
        DbSet<Test> Tests { get; set; }
    }
}
