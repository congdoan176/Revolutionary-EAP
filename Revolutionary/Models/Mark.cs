using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revolutionary.Models
{
    public class Mark
    {
        public static int MaxTheory = 100; //gia tri tinh theo %.
        public static int MaxPratice = 15;
        public static int MaxAssignment = 10;

        public Mark()
        {
            this.Value = 0;
            this.Type = MarkType.Theory;
            this.calculateMarkStatus();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        public Mark(MarkType type,int value)
        {
            this.Type = type;
            this.Value = value;
            this.calculateMarkStatus();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
        public float Value { get; set; }
        public MarkType Type { get; set; }
        public long SubjectId { get; set; }
        public long AccountId { get; set; }
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }
        public MarkStatus Status { get; set; }
        public Subject Subject { get; set; }        
        public Account Account { get; set; }

        public void calculateMarkStatus()
        {
            int maximum = 0;
            if (this.Type == MarkType.Theory)
            {
                maximum = MaxTheory;
            }else if(this.Type == MarkType.Practice)
            {
                maximum = MaxPratice;
            }else if (this.Type == MarkType.Assignment)
            {
                maximum = MaxAssignment;
            }
            this.Status = (this.Value / maximum) * 100 >= 40 ? MarkStatus.Pass : MarkStatus.Fail;
        }
    }
    
    public enum MarkType
    {
        Theory = 1,
        Practice = 2,
        Assignment = 3
    }
    public enum MarkStatus
    {
        Pass = 1,
        Fail = 0
    }
         
}
