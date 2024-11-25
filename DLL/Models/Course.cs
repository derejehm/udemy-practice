﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DLL.Model.Interfaces;

namespace DLL.Model
{
    public class Course : ISoftDeletable,ITrackable
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "decimal(18,4)")] 
        public decimal Credit { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }

        public ICollection<CourseStudent> CourseStudents { get; set; }
    }
}