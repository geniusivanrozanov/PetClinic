using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.DTOs.GetMethodDto
{
    public class GetVetDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Experience { get; set; }
        public string Bio { get; set; } = default!;
        public Guid DepartmentId { get; set; }
        public Guid? ClientId { get; set; }


    }
}
