using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsManager.Core.Contracts;
using ContactsManager.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.EndPoints.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactRepository contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }





        // GET api/Contacts
        [HttpGet]
        public IActionResult Get()
        {
            var result = contactRepository.Get();
            return Ok(result);
        }





        // GET api/Contacts/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = contactRepository.Get(id);
            return (result == null || result.ContactId < 1) ? (IActionResult)NotFound() : (IActionResult)Ok(result);
 
        }





        // POST api/Contacts
        [HttpPost]
        public IActionResult Post([FromBody] ContactDto  contactDto)
        {
            if(!ModelState.IsValid  )
            {
                return BadRequest (ModelState );
            }
            contactRepository.Add(new ContactDto() {FullName=contactDto .FullName , Phone =contactDto .Phone , Mobile =contactDto .Mobile  });
            return Ok();
        }





        // PUT api/Contacts/5
        [HttpPut("{id}")]
        public IActionResult Put(  int id,[FromBody]  ContactDto contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundContact = contactRepository.Get(id);

            if(foundContact==null)
            {
                return NotFound();
            }

            contactRepository.Update(id,new ContactDto() { FullName = contactDto.FullName, Phone = contactDto.Phone, Mobile = contactDto.Mobile });
            return Ok();
        }



        // DELETE api/Contacts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var foundContact = contactRepository.Get(id);
            if (foundContact == null)
            {
                return NotFound();
            }
            contactRepository.delete(id);
            return Ok();
        }



 


    }
}
