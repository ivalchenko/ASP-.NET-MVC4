using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace HelloWorld.Models
{
    public class Image
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string ImagePath { get; set; }

        [Required]
        public int ImageId { get; set; }
    }
}