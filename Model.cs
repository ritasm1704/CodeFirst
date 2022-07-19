using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst
{
    public class Inspection
    {
        public int InspectionId { get; set; }
        public string InspectionName { get; set; }
        public DateTime Date { get; set; }
        public string InspectorName { get; set; }
        public int InspectorId { get; set; }
        public virtual Inspector Inspector { get; set; }
        public string Comment { get; set; }
        public int NumberOfRemarks { get; set; }
        public virtual List<Remark> Remarks { get; set; }

        public override string ToString()
        {
            return InspectionName + ", " + Date + ", " + InspectorName + ", " + NumberOfRemarks;
        }

        //public override bool Equals(Object obj)
        //{
        //    Inspection insp = obj as Inspection;

        //    if (insp.InspectionId == this.InspectionId)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }

    public class Inspector
    {
        public int InspectorId { get; set; }
        public string InspectorName { get; set; }
        public string InspectorNumber { get; set; }
        public virtual List<Inspection> Inspections { get; set; }
        public string InspectorNameAndNumber
        {
            get { return InspectorName + " (" + InspectorNumber + ")"; }
            set { }
        }
        public override string ToString()
        {
            if(InspectorNumber == "") { return InspectorName; }
            return InspectorName + " (" + InspectorNumber + ")";
        }
    }

    public class Remark
    {
        public int RemarkId { get; set; }
        public string RemarkStr { get; set; }
        public DateTime DateOfFix { get; set; }
        public string Comment { get; set; }
        public int InspectionId { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
