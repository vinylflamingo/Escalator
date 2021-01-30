using System.Collections.Generic;
using System.Threading.Tasks;
using Escalator.Common.Models;

namespace Escalator.API.Contact
{
    public interface IContact
    {
        List<ContactRecord> CreateMessages();
        Task Submit();

    }
}