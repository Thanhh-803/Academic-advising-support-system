using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public bool? Status { get; set; }
        public string? Image { get; set; }
        public string? CreateBy { get; set; }
        public string? CreateDate { get; set; }
    }
}
