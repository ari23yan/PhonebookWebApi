using PhonebookWebApi.Data.Dtos;
using PhonebookWebApi.Data.Entities;
using PhonebookWebApi.Repository.Impelementation;
using PhonebookWebApi.Repository.Interfaces;
using PhonebookWebApi.Services.Interfaces;

namespace PhonebookWebApi.Services.Impelementation
{
    public class ContactServices: IContactServices
    {
        private readonly IContactRepository _contactRepository;
        public ContactServices(IContactRepository repository)
        {
            _contactRepository = repository;
        }

        public async Task CreateContact(ContactsDto dto)
        {
          await  _contactRepository.CreateContact(dto);
        }

        public async Task DeleteContact(string phoneNumber)
        {
          await  _contactRepository.DeleteContact(phoneNumber);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
          return   await  _contactRepository.GetAllContacts();
        }

        public async Task UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
