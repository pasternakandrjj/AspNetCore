using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Levi.Models
{
    public enum Importance { low, normal, high };

    public class MyTask
    {
        public string title { get; set; }

        public string description { get; set; }

        public Importance Importance { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public bool IsDone { get; set; }

        public MyTask()
        {
            Importance = Importance.normal;
            IsDone = false;
        }

        public MyTask(string title, string description, Importance Importance, DateTime DateTime, bool IsDone)
        {
            this.title = title;
            this.description = description;
            this.Importance = Importance;
            this.DateTime = DateTime;
            this.IsDone = IsDone;
        } 
    }
}
