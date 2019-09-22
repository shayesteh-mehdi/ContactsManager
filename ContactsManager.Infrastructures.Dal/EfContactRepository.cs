using ContactsManager.Core.Contracts;
using ContactsManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Infrastructures.Dal
{
    public class EfContactRepository : IContactRepository
    {
        ContactDbContext _ctx;

        public EfContactRepository(ContactDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(ContactDto contactDto)
        {
            _ctx.Add(new Contact() { FullName = contactDto.FullName, Mobile = contactDto.Mobile, Phone = contactDto.Phone });
            _ctx.SaveChanges();
        }

        public void delete(int Id)
        {
            //System.InvalidOperationException: 'The instance of entity type 'Contact' cannot be tracked because another instance with the same key value for {'ContactId'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.'
            //var contact = _ctx.contacts.Select(x => new Contact(x.ContactId)).FirstOrDefault(x => x.ContactId == Id);
            var contact = _ctx.contacts.FirstOrDefault(x => x.ContactId == Id);
            _ctx.Remove(contact);
            _ctx.SaveChanges();
        }

        public List<Contact> Get()
        {
            return _ctx.contacts.ToList();
        }

        public Contact Get(int Id)
        {
            return _ctx.contacts.FirstOrDefault(x => x.ContactId == Id);
        }

        public void Update(int Id, ContactDto contactDto)
        {
            var contact = Get(Id);
            contact.FullName = contactDto.FullName;
            contact.Mobile  = contactDto.Mobile;
            contact.Phone = contactDto.Phone;
            _ctx.SaveChanges();
        }
    }
}
