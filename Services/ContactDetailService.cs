using AddressBookAPI.Data;
using AddressBookAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Services
{
    public class ContactDetailService : IContactDetailService
    {
        private readonly AddressBookDbContext DbContext;

        public ContactDetailService(AddressBookDbContext context)
        {
            this.DbContext = context;
        }

        public IEnumerable<ContactDetail> GetAllContactDetails()
        {
            return this.DbContext.ContactDetails.ToList() ?? new List<ContactDetail>();
        }

        public ContactDetail GetContactDetail(int Id)
        {
            return this.DbContext.ContactDetails.SingleOrDefault(contact => contact.Id == Id);
        }

        public async Task<int> AddContactDetails(ContactDetail contact)
        {
            this.DbContext.ContactDetails.Add(contact);
            await this.DbContext.SaveChangesAsync();
            return contact.Id;
        }

        public bool UpdateContactDetails(int id, ContactDetail contact)
        {
            if (id == contact.Id)
            {
                try
                {
                    this.DbContext.ContactDetails.Update(contact);
                    this.DbContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }

        public bool DeleteContactById(int id)
        {
            if (this.DbContext.ContactDetails == null || (this.DbContext.ContactDetails.Any(e => e.Id == id) == null))
            {
                return false;
            }
            this.DbContext.ContactDetails.Remove(this.DbContext.ContactDetails.Find(id));
            this.DbContext.SaveChanges();
            return true;
        }
    }
}

