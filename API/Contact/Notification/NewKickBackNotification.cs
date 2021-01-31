using System.Collections.Generic;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Contact.Notification
{
    public class NewKickBackNotification : IContact
    {
        public ContactService contactService;
        public Ticket ticket;
        public DBContext context;
        public List<ContactRecord> newMessages;

        public NewKickBackNotification(Ticket _ticket, DBContext _context, IConfiguration config)
        {
            contactService = new ContactService(_context, config);
            context = _context;
            ticket = _ticket;
            newMessages = CreateMessages();
        }

        public List<ContactRecord> CreateMessages()
        {
            throw new System.NotImplementedException();
        }

        public async Task Submit()
        {
            foreach (ContactRecord msg in newMessages)
            {
                await contactService.Send(msg);
                await contactService.Save(msg);

            }
        }
    }
}