using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TwaWalletWeb_AspNetCore.Models
{
    public class TwaWalletWeb_AspNetCoreContext : DbContext
    {
        public TwaWalletWeb_AspNetCoreContext (DbContextOptions<TwaWalletWeb_AspNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<TwaWalletWeb_AspNetCore.Models.Movie> Movie { get; set; }
    }
}
