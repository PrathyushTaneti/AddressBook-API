using AddressBookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Services
{
    public interface IContactDetailService
    {
        ActionResult<IEnumerable<ContactDetail>> GetAllContactDetails();

        ContactDetail GetContactDetail(int id);

        bool UpdateContactDetails(int id, ContactDetail contact);

        int AddContactDetails(ContactDetail contact);

        bool DeleteContactById(int id);

    }
}

