using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Tag
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string TagName { get; set; }

        [Required]
        public int TagId { get; set; }

        public List<Post> Posts { get; set; }

        public override string ToString() {
            return TagName;
        }
    }
}