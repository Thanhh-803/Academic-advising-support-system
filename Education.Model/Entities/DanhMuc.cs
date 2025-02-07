using System;
using System.Collections.Generic;

namespace Education.Model.Entities
{
    public partial class DanhMuc
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? MoTa { get; set; }
    }
}
