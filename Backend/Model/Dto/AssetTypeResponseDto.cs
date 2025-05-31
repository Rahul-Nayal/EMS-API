using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class AssetTypeResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}