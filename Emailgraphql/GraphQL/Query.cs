using Emailgraphql.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace Emailgraphql.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(EmailContext))]
        public IQueryable<EmailStatus> GetEmails(
        [ScopedService] EmailContext emailContext)
        => emailContext.EmailsStatus;
    }
}
