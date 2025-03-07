using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaConMVC.Models;

public partial class Marca
{
    [Key]
    [Display(Name = "ID")]
    public int IdMarcas { get; set; }

    [Required(ErrorMessage = "El nombre de la marca no es opcional!")]
    [Display(Name = "Nombre de la Marca")]
    public string? NombreMarca { get; set; }


    [Display(Name = "Estado")]
    [StringLength(1, ErrorMessage = "La cantidad Maxima de caracteres valida es {1}")]
    public string? Estados { get; set; }
}
