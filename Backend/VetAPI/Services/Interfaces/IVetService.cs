using PetClinicApp.Shared.Data.Models;
using VetAPI.DTOs;

namespace VetAPI.Services
{
    public interface IVetService
    {
        Task<bool> CheckIfUserIsVet(int userId);
        Task<Vet> CreateVetAsync(CreateVetDTO dto);
    }
}
