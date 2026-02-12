using System.ComponentModel.DataAnnotations;

namespace Mission06_Springer.Models;

// Represents a single movie entry in the movie collection
public class Movie
{
    [Key]
    [Required]
    public int MovieID { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
    // ? means that it is not required

}