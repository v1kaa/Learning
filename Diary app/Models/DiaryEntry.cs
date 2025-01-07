using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
