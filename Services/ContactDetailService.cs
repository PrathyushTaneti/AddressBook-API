using AddressBookAPI.Data;
using AddressBookAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AddressBookAPI.Services
{
    public class ContactDetailService : IContactDetailService
    {

        private readonly AddressBookAPIContext DbContext;

        //public IMapper Mapper;

        public ContactDetailService(AddressBookAPIContext context)
        {
            this.DbContext = context;
           // this.Mapper = mapper;
        }
        public int AddContactDetails(ContactDetail contact)
        {
            if (this.DbContext.ContactDetails == null)
            {
                return -1;
            }
            this.DbContext.ContactDetails.Add(contact);
            this.DbContext.SaveChangesAsync();

            return contact.Id;
        }

        public bool DeleteContactById(int id)
        {
            if (this.DbContext.ContactDetails == null)
            {
                return false;
            }
            if (this.DbContext.ContactDetails.Find(id) == null)
            {
                return false;
            }
            else
            {
                this.DbContext.ContactDetails.Remove(this.DbContext.ContactDetails.Find(id));
                this.DbContext.SaveChanges();

                return true;
            }
        }

        public async Task<ActionResult<IEnumerable<ContactDetail>>> GetAllContactDetails()
        {
            if (this.DbContext.ContactDetails == null)
            {
                return new List<ContactDetail>();
            }
            return await this.DbContext.ContactDetails.ToListAsync();

        }

        public ContactDetail GetContactDetail(int Id)
        {
            if (this.DbContext.ContactDetails == null)
            {
                return null;
            }

            if (this.DbContext.ContactDetails.FindAsync(Id) == null)
            {
                return null;
            }

            return this.DbContext.ContactDetails.SingleOrDefault(contact => contact.Id == Id);
        }

        public bool UpdateContactDetails(int id, ContactDetail contact)
        {
            if (id != contact.Id)
            {
                return false;
            }

            this.DbContext.Entry(contact).State = EntityState.Modified;

            try
            {
                this.DbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.DoesContactDetailsExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }


        private bool DoesContactDetailsExists(int id)
        {
            return (this.DbContext.ContactDetails?.Any(e => e.Id == id)) == null;
        }

        ActionResult<IEnumerable<ContactDetail>> IContactDetailService.GetAllContactDetails()
        {
            throw new NotImplementedException();
        }
    }
}


/*
 * Task<int> IContactDetailService.AddContactDetails(ContactDetail contact)
        {
            throw new NotImplementedException();
        }

        bool IContactDetailService.DeleteContactById(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContactDetail>>> IContactDetailService.GetAllContactDetails()
        {
            throw new NotImplementedException();
        }

        Task<ContactDetail> IContactDetailService.GetContactDetail(int id)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IContactDetailService.UpdateContactDetails(int id, ContactDetail contact)
        {
            throw new NotImplementedException();
        }

*/