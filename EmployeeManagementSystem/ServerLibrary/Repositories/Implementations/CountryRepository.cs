using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CountryRepository (AppDbContext appDbContext) : IGenericRepository<Country>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Countrys.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Countrys.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await appDbContext.Countrys.ToListAsync();


        public async Task<Country> GetById(int id) => await appDbContext.Countrys.FindAsync(id);

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Country already exist");
            appDbContext.Countrys.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var country = await appDbContext.Countrys.FindAsync(item.Id);
            if (country is null) return NotFound();
            country.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry country not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Countrys.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

    }
}
