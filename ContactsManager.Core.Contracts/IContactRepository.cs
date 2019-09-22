using ContactsManager.Core.Domain;
using System;
using System.Collections.Generic;

namespace ContactsManager.Core.Contracts
{
    public interface IContactRepository
    {

        List<Contact> Get();
        Contact Get(int Id);
        void Add(ContactDto contactDto);
        void Update(int Id, ContactDto contactDto);
        void delete(int Id);


    }
}
