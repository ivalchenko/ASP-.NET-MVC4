using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System; 

namespace HelloWorld.Models
{
    public class Comment
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Date { get; set; }

        public int CommentId { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }

    public class EditCommentView
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CommentId { get; set; }
    }

    public class CreateCommentView
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}