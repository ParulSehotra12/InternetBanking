using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternetBanking.Models;

namespace InternetBanking.Data
{
    public class InternetBankingContext : DbContext
    {
        public InternetBankingContext (DbContextOptions<InternetBankingContext> options)
            : base(options)
        {
        }

        public DbSet<InternetBanking.Models.RegisterViewModel>? RegisterViewModel { get; set; }
    }
}
