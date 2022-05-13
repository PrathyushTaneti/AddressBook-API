using AddressBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Services
{
    public interface IContactDetailService
    {
        public IEnumerable<ContactDetail> GetAllContactDetails();
        
        public ContactDetail GetContactDetail(int id);
        
        public bool UpdateContactDetails(int id, ContactDetail contact);
        
        public Task<int> AddContactDetails(ContactDetail contact);
        
        public bool DeleteContactById(int id);

    }
}

