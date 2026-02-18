using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Springer.Models;

// Represents a single movie entry in the movie collection
public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; } // Here it is linking to the Category model I think, not CategoryName

    [Required(ErrorMessage = "Please enter a movie title")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter a year")]
    [Range(1888, 3000, ErrorMessage = "Year must be 1888 or later")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    
    [Required(ErrorMessage = "Please select whether or not the film was edited")]
    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
   
    [Required(ErrorMessage = "Please select whether or not the film was copied to Plex")]
    public bool? CopiedToPlex { get; set; }
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
    // ? means that it is not required

}