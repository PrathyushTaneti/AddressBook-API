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
        private readonly IContactDetailService ContactDetailsService;

        public ContactDetailsController(IContactDetailService service)
        {
            this.ContactDetailsService = service; 
        }

        // GET: api/ContactDetails
        [HttpGet]
        public IEnumerable<ContactDetail> GetContactDetails() 
        {
            return this.ContactDetailsService.GetAllContactDetails();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public ContactDetail GetContactDetails(int id)                                                                      
        {
            return this.ContactDetailsService.GetContactDetail(id);
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Task<int> PostContactDetails(ContactDetail contactDetails)
        {
            return this.ContactDetailsService.AddContactDetails(contactDetails);
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool PutContactDetails(int id, ContactDetail contactDetails)
        {
            return this.ContactDetailsService.UpdateContactDetails(id, contactDetails);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public bool DeleteContactDetails(int id)
        {
            return this.ContactDetailsService.DeleteContactById(id);
        }
    }
}


