﻿using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;
using System.ComponentModel;

namespace PhonebookWebApi.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task CreateContact(ContactsDto dto);
        Task<Contact> DeleteContact(string phoneNumber);
        Task<List<Contact>> GetAllContacts();
        Task<Contact>GetContact(string mobile);

    }
}
