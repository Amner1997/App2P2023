using System;
using System.Collections.Generic;
using System.Text;
using App2P2023.Models;
using SQLite;

namespace App2P2023.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombres { get; set; }

        [MaxLength(100)]
        public string Apellidos { get; set; }

        public DateTime FechaNac { get; set; }

        [MaxLength (20), Unique]
        public string Telefono { get; set; }

        public byte[] foto { get; set; }
    }
}
