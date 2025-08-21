using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recipe_Saver_App.Models;

public partial class Recipe
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public string RecipeName { get; set; } = null!;

    [Column("VideoURL")]
    public string? VideoUrl { get; set; }

    public string? Platform { get; set; }

    public string? CuisineType { get; set; }

    public string? MealType { get; set; }

    public decimal CaloriesPerServing { get; set; }

    public decimal FatPerServing { get; set; }

    public decimal CarbsPerServing { get; set; }

    public decimal ProteinPerServing { get; set; }

    public int IsFavourite { get; set; }

    public int PlanToCook { get; set; }

    public decimal? Rating { get; set; }

    public DateOnly? LastMade { get; set; }

    public string? Notes { get; set; }

    [InverseProperty("Recipe")]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
