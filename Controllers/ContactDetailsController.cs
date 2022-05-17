using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddressBookAPI.Data;
using AddressBookAPI.Models;
using System.Collections;
using AddressBookAPI.Services;


namespace AddressBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailsController : ControllerBase
    {
        private readonly IContactDetailService ContactDetailService;

        public ContactDetailsController(IContactDetailService service)
        {
            this.ContactDetailService = service; 
        }

        // GET: api/ContactDetails
        [HttpGet]
        public IEnumerable<ContactDetail> GetContactDetails() 
        {
            return this.ContactDetailService.GetAllContactDetails();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public ContactDetail GetContactDetail(int id)                                                                      
        {
            return this.ContactDetailService.GetContactDetail(id);
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Task<int> PostContactDetail(ContactDetail contactDetail)
        {
            return this.ContactDetailService.AddContactDetail(contactDetail);
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool PutContactDetail(int id, ContactDetail contactDetail)
        {
            return this.ContactDetailService.UpdateContactDetail(id, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public bool DeleteContactDetail(int id)
        {
            return this.ContactDetailService.DeleteContactById(id);
        }
    }
}


