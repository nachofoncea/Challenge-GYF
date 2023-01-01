using System;
using System.Collections.Generic;

namespace ChallengeGYF.DAL.EF.Models;

public partial class Producto
{
    public int ProductoID { get; set; }

    public int Precio { get; set; }

    public DateTime FechaCarga { get; set; }

    public int CategoriaID { get; set; }

    public string? Observaciones { get; set; }

    public virtual Categoria Categoria { get; set; } 
}
