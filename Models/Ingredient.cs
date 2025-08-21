using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recipe_Saver_App.Models;

public partial class Ingredient
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public string IngredientName { get; set; } = null!;

    public int NeedDefrosting { get; set; }

    public int IsCommonlyAvail { get; set; }

    [InverseProperty("Ingredient")]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
