﻿using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class VacationTypeRepository(AppDbContext appDbContext) : IGenericRepository<VacationType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.VacationsTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.VacationsTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<VacationType>> GetAll() => await appDbContext
        .VacationsTypes.AsNoTracking().ToListAsync();


        public async Task<VacationType> GetById(int id) => await appDbContext
            .VacationsTypes.FindAsync(id);



        public async Task<GeneralResponse> Insert(VacationType item)
        {
            var isCheckName = await CheckName(item.Name);
            if (!isCheckName)
                return new GeneralResponse(false, "Sanction Type already added");
            appDbContext.VacationsTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(VacationType item)
        {
            var obj = await appDbContext.VacationsTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry type not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.VacationsTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
