using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Data
{
    public abstract class ServiceObject
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public ServiceObject()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
