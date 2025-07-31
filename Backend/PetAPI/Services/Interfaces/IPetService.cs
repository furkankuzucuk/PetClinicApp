using PetAPI.DTOs;

namespace PetAPI.Services
{
    public interface IPetService
    {
        Task<PetDTO> CreatePetAsync(CreatePetDTO dto);
        Task<IEnumerable<PetDTO>> GetUserPetsAsync(int userId);
    }
}
