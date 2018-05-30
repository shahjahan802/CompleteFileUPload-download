using System;
using System.Collections.Generic;

namespace FileUpload26MayTest.Models
{
    public partial class FormTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNo { get; set; }
        public string FilePath { get; set; }
        public string FileDownload { get; set; }
        public string  Email { get; set; }


    }
}
