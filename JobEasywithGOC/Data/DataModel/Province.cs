﻿using System.ComponentModel.DataAnnotations;

namespace JobEasyWithGOC.Data.DataModel
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
