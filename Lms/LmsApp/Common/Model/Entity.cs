﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    [Serializable]
    public class Entity
    {
        public string Id { get; set; }
        
        public DataType Created { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime Modified { get; set; }
        
        public string ModifiedBy { get; set; }
        
        public bool IsActive { get; set; }  //can be toggled
        
        public bool IsDeleted { get; set; } //can not be toggled
    }
}
