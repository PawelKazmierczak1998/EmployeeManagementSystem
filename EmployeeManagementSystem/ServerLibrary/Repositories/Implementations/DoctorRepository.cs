﻿using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class DoctorRepository(AppDbContext appDbContext) : IGenericRepository<Doctor>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Doctors.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.Doctors.Remove(item);
            await Commit();

            return Success();

        }

        public async Task<List<Doctor>> GetAll() => await appDbContext
            .Doctors
            .AsNoTracking()
            .ToListAsync();


        public async Task<Doctor> GetById(int id) => await appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.Id == id);


        public async Task<GeneralResponse> Insert(Doctor item)
        {
            appDbContext.Doctors.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Doctor item)
        {
            var obj = await appDbContext.Doctors.FirstOrDefaultAsync(eid => eid.Id == item.Id);
            if (obj is null) return NotFound();
            obj.MedicalRecommendation = item.MedicalRecommendation;
            obj.MedicalDiagnose = item.MedicalDiagnose;
            obj.Date = item.Date;
            obj.EmployeeId = item.EmployeeId;
            await Commit();
            return Success();
        }


        private static GeneralResponse NotFound() => new(false, "Sorry doctor note not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task Commit() => await appDbContext.SaveChangesAsync();

    }
}
