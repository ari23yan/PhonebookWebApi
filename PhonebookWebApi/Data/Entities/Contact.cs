using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhonebookWebApi.Data.Entities
{
    public class Contact
    {
        [Key]
        public Int64 id { get; set; }
        [Required(ErrorMessage = "Please Insert Your  First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Insert Your  Last Name ")]
        public string LastName { get; set; }
        [Range(10,12)]
        [Required(ErrorMessage = "Please Insert Your  Phone Number ")]
        [MaxLength(20,ErrorMessage ="Phone Number Must Be Less Than 20 Number")]
        public string PhoneNumber { get; set; }
        public bool IsDeleted  { get; set; }
    }
}
