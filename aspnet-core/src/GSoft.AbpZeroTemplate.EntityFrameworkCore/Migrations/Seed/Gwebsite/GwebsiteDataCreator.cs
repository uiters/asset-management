using GSoft.AbpZeroTemplate.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace GSoft.AbpZeroTemplate.Migrations.Seed.Gwebsite
{
    public class GwebsiteDataCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public GwebsiteDataCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDataFromFile();
        }

        private void CreateDataFromFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = baseDir.Substring(0, baseDir.IndexOf("\\bin")) + "\\scripts_seeder";
            string file = baseDir + "\\gwebsite3.sql";
            _context.Database.ExecuteSqlCommand(File.ReadAllText(file));
            _context.SaveChanges();
        }
    }
}
