using System.ComponentModel.DataAnnotations.Schema;
namespace LanguageSchool.Models;

using Microsoft.EntityFrameworkCore;

public class Assessment
{
    public int Id { get; set; }
    [Column("class_id")]
    public int ClassId { get; set; }
   
    [Column("title")]
    public string Title { get; set; }
    [Column("max_score")]
    public decimal MaxScore{get; set;}
}
