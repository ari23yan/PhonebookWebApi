using Microsoft.EntityFrameworkCore;
using PhonebookWebApi.Data.Context;
using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;
using PhonebookWebApi.Repositories.Interfaces;
using PhonebookWebApi.Repository.Interfaces;

namespace PhonebookWebApi.Repository.Impelementation
{
    public class ContactRepository: IContactRepository
    {
        private readonly PhoneBookWebApiDbContext _context;
        private readonly IGenerciRepository<Contact> _contactGenerciRepository;
        public ContactRepository(PhoneBookWebApiDbContext dbContext, IGenerciRepository<Contact> contactGenerciRepository)
        {
            _context = dbContext;
            _contactGenerciRepository = contactGenerciRepository;
        }
        public async Task CreateContact(ContactsDto dto)
        {
 
            Contact contact = new Contact
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                IsDeleted = false
            };
             await _contactGenerciRepository.AddAsync(contact);
             await _context.SaveChangesAsync();
        }

        public async Task<Contact> DeleteContact(string phoneNumber)
        {
           return  await  _context.Contacts.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.Where(a=>a.IsDeleted == false).ToListAsync();
        }

        public async Task<Contact> GetContact(string mobile)
        {
            return await _context.Contacts.FirstOrDefaultAsync(u => u.PhoneNumber == mobile);
        }
    }
}
