using System.ComponentModel.DataAnnotations;

namespace PhonebookWebApi.Data.Dtos
{
    public class ContactsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
