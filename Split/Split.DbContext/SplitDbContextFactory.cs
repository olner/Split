using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.DbContexts
{
    public class SplitDbContextFactory : IDesignTimeDbContextFactory<SplitDbContext>
    {
        public SplitDbContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
            var optionsBuilder = new DbContextOptionsBuilder<SplitDbContext>();
            //TODO: Брать connectionstring из файла
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=split;port=3306;User Id=root;password=Olegka_2003",
                new MySqlServerVersion(new Version(8, 0, 30)));

            return new SplitDbContext(optionsBuilder.Options);
        }
    }
}
