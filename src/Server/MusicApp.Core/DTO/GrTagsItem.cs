using MusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Core.DTO
{
    public class GrTagsItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public bool Enable { get; set; }

        public IList<Tag> Tags { get; set; }
    }
}
