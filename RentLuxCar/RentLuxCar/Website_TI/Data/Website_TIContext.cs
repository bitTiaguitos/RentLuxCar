﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Website_TI.Models.DTO;

namespace Website_TI.Data
{
    public class Website_TIContext : DbContext
    {
        public Website_TIContext (DbContextOptions<Website_TIContext> options)
            : base(options)
        {
        }

        public DbSet<Website_TI.Models.DTO.Viaturas> Viaturas { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.TipoDeViaturas> TipoDeViaturas { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.Aluguer> Aluguer { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.Cliente> Cliente { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.CredenciaisCliente> CredenciaisCliente { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.Pagamentos> Pagamentos { get; set; } = default!;
        public DbSet<Website_TI.Models.DTO.MetodoPagamentos> MetodoPagamentos { get; set; } = default!;
    }
}
