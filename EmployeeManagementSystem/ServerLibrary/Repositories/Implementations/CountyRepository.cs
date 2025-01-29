using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class CountyRepository(AppDbContext appDbContext) : IGenericRepository<County>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Counties.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Counties.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<County>> GetAll() => await appDbContext.Counties
            .AsNoTracking()
            .Include(ci=>ci.Country)
            .ToListAsync();


        public async Task<County> GetById(int id) => await appDbContext.Counties.FindAsync(id);

        public async Task<GeneralResponse> Insert(County item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "County already exist");
            appDbContext.Counties.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(County item)
        {
            var county = await appDbContext.Counties.FindAsync(item.Id);
            if (county is null) return NotFound();
            county.Name = item.Name;
            county.CountryId = item.CountryId;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry county not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Counties.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

    }
}
