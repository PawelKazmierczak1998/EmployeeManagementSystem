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
    public class SanctionTypeRepository(AppDbContext appDbContext) :IGenericRepository<SanctionType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.SanctionTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.SanctionTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<SanctionType>> GetAll() => await appDbContext
        .SanctionTypes.AsNoTracking().ToListAsync();


        public async Task<SanctionType> GetById(int id) => await appDbContext
            .SanctionTypes.FindAsync(id);



        public async Task<GeneralResponse> Insert(SanctionType item)
        {
            var isCheckName = await CheckName(item.Name);
            if (!isCheckName)
                return new GeneralResponse(false, "Sanction Type already added");
            appDbContext.SanctionTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(SanctionType item)
        {
            var obj = await appDbContext.SanctionTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry type not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.SanctionTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
