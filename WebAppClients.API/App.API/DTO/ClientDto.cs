using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.DTO
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }        

        public DateTime Birthday { get; set; }

        public DateTime Created { get; set; }

        public string Comment { get; set; }
    }
}
