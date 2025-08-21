using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recipe_Saver_App.Models;

[Index("IngredientId", Name = "IX_RecipeIngredients_IngredientID")]
[Index("RecipeId", Name = "IX_RecipeIngredients_RecipeID")]
public partial class RecipeIngredient
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RecipeID")]
    public int RecipeId { get; set; }

    [Column("IngredientID")]
    public int IngredientId { get; set; }

    public string Amount { get; set; } = null!;

    public string Quantifier { get; set; } = null!;

    [ForeignKey("IngredientId")]
    [InverseProperty("RecipeIngredients")]
    public virtual Ingredient Ingredient { get; set; } = null!;

    [ForeignKey("RecipeId")]
    [InverseProperty("RecipeIngredients")]
    public virtual Recipe Recipe { get; set; } = null!;
}
