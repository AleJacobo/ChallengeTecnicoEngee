using Domain.Entities.EntityBases;
using System.ComponentModel.DataAnnotations;

namespace ChallengeTecnicoEngee.Domain.Entities.EntityBases
{
    public class TypeBase : EntityBase
    {

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Codigo { get; set; }
    }
}
