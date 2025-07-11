using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class AssetType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? AssetImageUrl { get; set; }
        [ForeignKey("AssetImageUrl")]
        public Image? AssetImage { get; set; }

    }
}