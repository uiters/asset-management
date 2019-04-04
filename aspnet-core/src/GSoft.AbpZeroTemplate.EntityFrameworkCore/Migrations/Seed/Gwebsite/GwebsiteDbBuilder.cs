using GSoft.AbpZeroTemplate.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Migrations.Seed.Gwebsite
{
    public class GwebsiteDbBuilder
    {
        private readonly AbpZeroTemplateDbContext _context;

        public GwebsiteDbBuilder(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new GwebsiteDataCreator(_context).Create();
        }
    }
}
