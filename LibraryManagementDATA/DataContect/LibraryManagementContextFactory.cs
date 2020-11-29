using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementDATA.DataContect
{
    public class LibraryManagementContextFactory : IDesignTimeDbContextFactory<LibraryManagementContext>
    {
        public LibraryManagementContext CreateDbContext(string[] args)
        {
            var stringDeConexao = "Server = (localdb)\\mssqllocaldb;Database=LibraryManagement;Trusted_Connection=True;MultipleActiveResultSets=true";
            var opcoesDeConstrucao = new DbContextOptionsBuilder<LibraryManagementContext>();
            opcoesDeConstrucao.UseSqlServer(stringDeConexao);
            return new LibraryManagementContext(opcoesDeConstrucao.Options);
        }
    }
}
