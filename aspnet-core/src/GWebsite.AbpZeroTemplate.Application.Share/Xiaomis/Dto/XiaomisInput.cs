using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Xiaomis.Dto
{
    /// <summary>
    /// <model cref="Xiaomis"></model>
    /// </summary>
    public class XiaomisInput :Entity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
    }
}
