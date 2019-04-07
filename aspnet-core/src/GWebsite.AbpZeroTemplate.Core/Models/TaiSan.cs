using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class TaiSan:Entity<int>
    {
        public string TenTaiSan { get; set; }
        public string LoaiTaiSan { get; set; }
        public string NguyenGia { get; set; }
        public int? TrangThai { get; set; }
        public int? SoLuong { get; set; }
    }
}
