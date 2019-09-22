using System;

namespace ContactsManager.Core.Domain
{
    public class Contact
    {
        public int ContactId { get; private set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public Contact()
        { }

        public Contact(int ContactId)
        {
            this.ContactId = ContactId;
        }

    }
}

