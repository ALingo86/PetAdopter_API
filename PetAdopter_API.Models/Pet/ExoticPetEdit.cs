﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopter_API.Models.Pet
{
    public class ExoticPetEdit
    {
        public int ExoticId { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Adopter))]
        public int AdopterId { get; set; }
    }
}
