using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Context
{
    public class WpfAppApiContext : DbContext
    {
        public WpfAppApiContext(DbContextOptions<WpfAppApiContext> options) : base(options)
        { }

        public DbSet<ListProperty> ListProperty { get; set; }
        public DbSet<ItemProperty> ItemProperty { get; set; }
    }
}
