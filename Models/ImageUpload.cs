using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class ImageUpload
    {
        [Key]
           public int Id { get; set; }
            public string Name { get; set; }

        public string Contact { get; set; }
        public string Address { get; set; }


        public string Image { get; set; }
        }
    }

