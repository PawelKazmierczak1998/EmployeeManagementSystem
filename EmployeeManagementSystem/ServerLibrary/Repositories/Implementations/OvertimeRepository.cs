﻿using BaseLibrary.Entities;
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
    public class OvertimeRepository(AppDbContext appDbContext) : IGenericRepository<Overtime>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if(item is null) return NotFound();

            appDbContext.Overtimes.Remove(item);    
            await Commit();
            return Success();
        }

        public async Task<List<Overtime>> GetAll() => await appDbContext
            .Overtimes
            .AsNoTracking()
            .Include(o=>o.OvertimeType)
            .ToListAsync();


        public async Task<Overtime> GetById(int id) => await appDbContext
            .Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            


        public async Task<GeneralResponse> Insert(Overtime item)
        {
            appDbContext.Overtimes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Overtime item)
        {
           var obj = await appDbContext.Overtimes.FirstOrDefaultAsync(eid=>eid.EmployeeId == item.EmployeeId);
            if(obj is null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.EndDate = item.EndDate;
            obj.OvertimeTypeId = item.OvertimeTypeId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry overtime not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
