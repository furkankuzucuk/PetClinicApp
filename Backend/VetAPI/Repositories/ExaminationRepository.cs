using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;
using VetAPI.Data;
using VetAPI.Repositories.Interfaces;

namespace VetAPI.Repositories
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly VetDbContext _context;

        public ExaminationRepository(VetDbContext context)
        {
            _context = context;
        }

        public async Task<Examination> AddExaminationAsync(Examination examination)
        {
            _context.Examinations.Add(examination);
            await _context.SaveChangesAsync();
            return examination;
        }

        public async Task<List<Examination>> GetExaminationsByPetIdAsync(int petId)
        {
            return await _context.Examinations
                .Where(e => e.PetId == petId)
                .OrderByDescending(e => e.ExaminationDate)
                .ToListAsync();
        }
    }
}
