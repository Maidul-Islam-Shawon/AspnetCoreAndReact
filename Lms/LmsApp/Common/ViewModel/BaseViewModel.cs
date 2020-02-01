using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.ViewModel
{
    public class BaseViewModel
    {
        public BaseViewModel(Entity entity)
        {
            Id = entity.Id;
            Created = entity.Created;
            CreatedBy = entity.CreatedBy;
            Modified = entity.Modified;
            ModifiedBy = entity.ModifiedBy;
            IsActive = entity.IsActive;
            IsDeleted = entity.IsDeleted;
        }

        public string Id { get; private set; }


        public DataType Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsActive { get; set; }  //can be toggled

        public bool IsDeleted { get; set; }
    }
}
