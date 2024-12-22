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
    public class CityRepository(AppDbContext appDbContext) : IGenericRepository<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Citys.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Citys.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await appDbContext.Citys
            .AsNoTracking()
            .Include(ci=>ci.Country)
            .ToListAsync();


        public async Task<City> GetById(int id) => await appDbContext.Citys.FindAsync(id);

        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Branch already exist");
            appDbContext.Citys.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDbContext.Citys.FindAsync(item.Id);
            if (city is null) return NotFound();
            city.Name = item.Name;
            city.CountryId = item.CountryId;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry branch not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Citys.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

    }
}
