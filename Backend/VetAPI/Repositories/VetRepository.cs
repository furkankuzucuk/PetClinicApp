using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;
using VetAPI.Data;

namespace VetAPI.Repositories
{
    public class VetRepository : IVetRepository
    {
        private readonly VetDbContext _context;

        public VetRepository(VetDbContext context)
        {
            _context = context;
        }

        public async Task<Vet> AddVetAsync(Vet vet)
        {
            _context.Vets.Add(vet);
            await _context.SaveChangesAsync();
            return vet;
        }

        public async Task<Vet?> GetVetByUserIdAsync(int userId)
        {
            return await _context.Vets.FirstOrDefaultAsync(v => v.UserId == userId);
        }
    }
}
