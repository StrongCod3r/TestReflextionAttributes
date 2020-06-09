using System;
using System.Collections.Generic;
using System.Text;
using TestReflextionAttributes.SP;

namespace TestReflextionAttributes.Models
{
    [ListAttrib(Name = "MyTest")]
    public class TestModel
    {
        public int Id { get; set; }

        [ListItemAttrib(Name = "MyName",DisplayName = "Nombre")]
        public string Name { get; set; }

        [ListItemAttrib(DisplayName = "Apellido")]
        public string SurName { get; set; }

        [ListItemAttrib(Name = "Fecha de nacimiento")]
        public DateTime? BirthDate { get; set; }

        [ListItemAttrib(DisplayName = "Activo")]
        public bool? IsActive { get; set; }

    }
}
