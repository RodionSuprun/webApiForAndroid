using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiForAndroid.Models
{
    public class HotelsContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public HotelsContext(DbContextOptions<HotelsContext> options)
            : base(options)
        { }
    }
}
