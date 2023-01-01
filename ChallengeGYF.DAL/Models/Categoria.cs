using System;
using System.Collections.Generic;

namespace ChallengeGYF.DAL.EF.Models;

public partial class Categoria
{
    public int CategoriaID { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual ICollection<Producto> Producto { get; } = new List<Producto>();
}
