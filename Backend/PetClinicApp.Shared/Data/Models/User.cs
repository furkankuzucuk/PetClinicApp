using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicApp.Shared.Data.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        // Navigation
        [NotMapped]
        public ICollection<UserRoleJoin> UserRoleJoins { get; set; }
    }
}
