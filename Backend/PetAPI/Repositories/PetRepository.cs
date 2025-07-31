using Microsoft.EntityFrameworkCore;
using PetAPI.Data;
using PetClinicApp.Shared.Data.Models;

namespace PetAPI.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetDbContext _context;

        public PetRepository(PetDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<IEnumerable<Pet>> GetPetsByUserIdAsync(int userId)
        {
            return await _context.Pets.Where(p => p.UserId == userId).ToListAsync();
        }
    }
}
