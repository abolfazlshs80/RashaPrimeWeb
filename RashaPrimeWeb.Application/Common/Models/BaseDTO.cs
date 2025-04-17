using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RashaPrimeWeb.Application.Common.Models
{
    public record BaseDTO
    {
        public int Id { get; set; }

        public bool Status { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
