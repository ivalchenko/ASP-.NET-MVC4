using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelloWorld.Models
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }

        public List<Tag> Tags { get; set; }
        
        public List<Comment> Comments { get; set; }

        [Required]
        public int CommentsNumber { get; set; }

        [Required]
        public int LikesNumber { get; set; }     
    }

    public class CreatePostView
    {
        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Please select a tag")]
        public string SelectedTag { get; set; }
        public SelectList TagList { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}