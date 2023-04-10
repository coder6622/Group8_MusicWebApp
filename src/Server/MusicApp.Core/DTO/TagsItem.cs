using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Core.DTO
{
    public class TagsItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }

        public Guid GroupTagId { get; set; }

        public GroupTag GroupTag { get; set; }   
    }
}
