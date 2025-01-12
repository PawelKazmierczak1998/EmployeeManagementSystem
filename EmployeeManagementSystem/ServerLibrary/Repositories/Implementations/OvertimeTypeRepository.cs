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
    public class OvertimeTypeRepository(AppDbContext appDbContext) : IGenericRepository<OvertimeType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.OvertimesTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.OvertimesTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<OvertimeType>> GetAll() => await appDbContext
            .OvertimesTypes
            .AsNoTracking()
            .ToListAsync();


        public async Task<OvertimeType> GetById(int id) => await appDbContext
            .OvertimesTypes.FindAsync(id);



        public async Task<GeneralResponse> Insert(OvertimeType item)
        {
            var isCheckName = await CheckName(item.Name);
            if (!isCheckName)
                return new GeneralResponse(false,"Overtime Type already added");
            appDbContext.OvertimesTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(OvertimeType item)
        {
            var obj = await appDbContext.OvertimesTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();
            
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry type not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.OvertimesTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
