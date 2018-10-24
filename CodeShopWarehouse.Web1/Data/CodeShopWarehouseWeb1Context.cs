using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Web1.Models
{
    public class CodeShopWarehouseWeb1Context : DbContext
    {
        public CodeShopWarehouseWeb1Context (DbContextOptions<CodeShopWarehouseWeb1Context> options)
            : base(options)
        {
        }

        public DbSet<CodeShopWarehouse.Entities.Order> Order { get; set; }
    }
}
