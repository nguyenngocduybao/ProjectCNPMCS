using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class DieuChuyen :FullAuditModel
    {
        public String TenDVDieuChuyen { get; set; }
        public int? SoLuong { get; set; }
        public int? MaTaiSan { get; set; }
        public DateTime NgayDieuChuyen { get; set; }
        public String TenDVDuocDieuChuyen { get; set; }
    }
}
