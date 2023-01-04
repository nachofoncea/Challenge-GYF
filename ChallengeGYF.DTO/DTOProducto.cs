using System;

namespace ChallengeGYF.Shared.DTO
{
    public class DTOProducto
    {
        public int ProductoID { get; set; }
        public int Precio { get; set; }
        public DateTime FechaCarga { get; set; }
        public int CategoriaID { get; set; }
        public string? Categoria { get; set; }
        public string? Observaciones { get; set; }

    }
}
