using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class Post
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /*[Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; */

        public int PostId { get; set; }
    }

    public class EditPostView
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int PostId { get; set; }
    }

    public class CreatePostView
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /*[Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }*/
    }
}