using PetAPI.DTOs;
using PetAPI.Repositories;
using PetClinicApp.Shared.Data.Models;

namespace PetAPI.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<PetDTO> CreatePetAsync(CreatePetDTO dto)
        {
            var pet = new Pet
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Species = dto.Species,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                ChipNumber = dto.ChipNumber
            };

            var created = await _petRepository.AddPetAsync(pet);
            return new PetDTO
            {
                Id = created.Id,
                UserId = created.UserId,
                Name = created.Name,
                Species = created.Species,
                Gender = created.Gender,
                DateOfBirth = created.DateOfBirth,
                ChipNumber = created.ChipNumber
            };
        }

        public async Task<IEnumerable<PetDTO>> GetUserPetsAsync(int userId)
        {
            var pets = await _petRepository.GetPetsByUserIdAsync(userId);
            return pets.Select(p => new PetDTO
            {
                Id = p.Id,
                UserId = p.UserId,
                Name = p.Name,
                Species = p.Species,
                Gender = p.Gender,
                DateOfBirth = p.DateOfBirth,
                ChipNumber = p.ChipNumber
            });
        }
    }
}
