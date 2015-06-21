using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class PostComment
    {
        [Required]
        //[DataType(DataType.)]
        public Post Post { get; set; }

        [Required]
        //[DataType(DataType.)]
        //public Comment Comment { get; set; }
        //public List<Comment> Comments {get; set;}
        public IEnumerable<Comment> Comments { get; set; }

        public int PostCommentId { get; set; }
    }
}
