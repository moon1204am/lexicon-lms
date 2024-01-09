using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Shared.Dtos
{
    public class DocumentDto
    {
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = default!;
        public DateTime UploadDate { get; set; } 
        public string UserId { get; set; } = string.Empty;
    }

    
}
