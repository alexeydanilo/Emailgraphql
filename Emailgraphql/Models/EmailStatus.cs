using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Emailgraphql.Models
{
    public class EmailStatus
    {
        [Key]
        public int Id { get; set; }

        public string SentTo { get; set; }

        public string Status { get; set; }

    }
}
