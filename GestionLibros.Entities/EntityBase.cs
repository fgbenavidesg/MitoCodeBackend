using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Entities
{
    public class EntityBase
    {
        public string Id { get; set; } = default!;
        public bool Status { get; set; } = true;
    }
}
