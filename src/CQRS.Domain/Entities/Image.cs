using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace CQRS.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }        
        public string Values { get; set; }

        [NotMapped]
        public virtual IList<string> Images
        {
            get
            {
                return Values.Split(',');
            }
            set
            {
                Values = value.ToArray().Join(",");
            }
        }
    }
}