using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime UploadDate { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
