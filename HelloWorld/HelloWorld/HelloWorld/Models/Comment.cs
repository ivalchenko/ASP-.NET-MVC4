using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System; 
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; }

        public Post Post {get; set;}
        public string AuthorId { get; set; }
        //[Required]
        //public IdentityUser User { get; set; }
    }

    public class PostComment
    {
        [Required]
        //[DataType(DataType.Text)]
        public Post Post { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        public List<Comment> Comments { get; set; }

        [Required]
        public int PostCommentId { get; set; }
    }
}