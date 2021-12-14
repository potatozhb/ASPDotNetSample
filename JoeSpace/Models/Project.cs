using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JoeSpace.Models
{
    public class Project
    {
        private int id;
        [Key]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [Range(1,100,ErrorMessage ="DIsplay Order range must be between 1 and 100 only!")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;

    }
}
