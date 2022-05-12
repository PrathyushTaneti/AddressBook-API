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
        private readonly IContactDetailService Services;

        public ContactDetailsController(IContactDetailService service)
        {
            this.Services = service; 
        }

        // GET: api/ContactDetails
        [HttpGet]
        public ActionResult<IEnumerable<ContactDetail>> GetContactDetails() ///
        {
            return this.Services.GetAllContactDetails();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public ContactDetail GetContactDetails(int id)                                                                      
        {
            return this.Services.GetContactDetail(id);
        }

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public int PostContactDetails(ContactDetail contactDetails)
        {
            return this.Services.AddContactDetails(contactDetails);
        }


        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public bool PutContactDetails(int id, ContactDetail contactDetails)
        {
            return this.Services.UpdateContactDetails(id, contactDetails);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public bool DeleteContactDetails(int id)
        {
            return this.Services.DeleteContactById(id);
        }
    }
}


/*
 * actionresult - contact details, list, bool
 * all details - ien
 * add - return id of detail
 * update,delete - bool 
 * 
 */