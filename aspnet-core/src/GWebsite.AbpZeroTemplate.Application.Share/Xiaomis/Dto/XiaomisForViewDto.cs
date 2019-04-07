﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;


namespace GWebsite.AbpZeroTemplate.Application.Share.Xiaomis.Dto
{
    /// <summary>
    /// <model cref="Xiaomi"></model>
    /// </summary>
    public class XiaomisForViewDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
    }
}