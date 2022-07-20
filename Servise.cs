using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Servise
    {
        public Inspection AddInspection(Inspection inspection)
        {
            using (MyContext db = new MyContext())
            {
                db.Inspections.Add(inspection);
                db.SaveChanges();

                return inspection;
            }
        }

        public Remark AddRemark(Remark remark)
        {
            using (MyContext db = new MyContext())
            {
                db.Inspections.Find(remark.InspectionId).NumberOfRemarks++;

                db.Remarks.Add(remark);
                db.SaveChanges();

                return remark;
            }
        }

        public Inspector AddInspector(Inspector inspector)
        {
            using (MyContext db = new MyContext())
            {
                db.Inspectors.Add(inspector);
                db.SaveChanges();

                return inspector;
            }
        }

        public Inspector DeleteInspector(string number)
        {
            using (MyContext db = new MyContext())
            {
                List<Inspector> inspectors = db.Inspectors.Where<Inspector>(i => i.InspectorNumber == number).ToList();
                db.Inspectors.Remove(inspectors[0]);
                db.SaveChanges();

                return inspectors[0];
            }
        }

        public List<Inspection> GetAllInspections()
        {
            using (MyContext db = new MyContext())
            {
                List<Inspection> inspections = db.Inspections.ToList();

                return inspections;
            }
        }

        public List<Inspection> GetInspectionByInspectionName(string inspectionName)
        {
            using (MyContext db = new MyContext())
            {
                List<Inspection> inspections = db.Inspections.Where<Inspection>
                    (i => i.InspectionName.StartsWith(inspectionName)).ToList();

                return inspections;
            }
        }

        public List<Inspection> GetInspectionByInspector(Inspector inspector)
        {
            using (MyContext db = new MyContext())
            {
                List<Inspection> inspections = db.Inspections.Where<Inspection>
                    (i => i.Inspector.InspectorId == inspector.InspectorId).ToList();

                return inspections;
            }
        }

        public List<Remark> GetRemarks(Inspection inspection)
        {
            using (MyContext db = new MyContext())
            {
                List<Remark> remarks = db.Remarks.Where<Remark>
                    (r => r.Inspection.InspectionId == inspection.InspectionId).ToList();

                return remarks;
            }
        }

        public List<Inspector> GetInspectors()
        {
            using (MyContext db = new MyContext())
            {
                List<Inspector> inspectors = db.Inspectors.ToList();

                return inspectors;
            }
        }

        public void DeleteInspection(int InspectionId)
        {
            using (MyContext db = new MyContext())
            {
                List<Inspection> inspections = db.Inspections.Where<Inspection>(i => i.InspectionId == InspectionId).ToList();
                db.Inspections.Remove(inspections[0]);
                db.SaveChanges();
            }
        }

        public void DeleteRemark(Remark remark)
        {
            using (MyContext db = new MyContext())
            {
                db.Inspections.Find(remark.InspectionId).NumberOfRemarks--;

                List<Remark> remarks = db.Remarks.Where<Remark>(i => i.RemarkId == remark.RemarkId).ToList();
                db.Remarks.Remove(remarks[0]);
                db.SaveChanges();
            }
        }

        public void EditInspection(Inspection inspection)
        {
            using (MyContext db = new MyContext())
            {
                Inspection insp = db.Inspections.Find(inspection.InspectionId);

                insp.InspectionName = inspection.InspectionName;
                insp.Date = inspection.Date;
                insp.InspectorId = inspection.InspectionId;
                insp.InspectorName = inspection.InspectorName;
                insp.Comment = inspection.Comment;

                db.SaveChanges();
            }
        }

        public void EditRemark(Remark remark)
        {
            using (MyContext db = new MyContext())
            {
                Remark rem = db.Remarks.Find(remark.RemarkId);

                rem.RemarkStr = remark.RemarkStr;
                rem.DateOfFix = remark.DateOfFix;
                rem.Comment = remark.Comment;

                db.SaveChanges();
            }
        }

        public void EditInspector(Inspector inspector)
        {
            using (MyContext db = new MyContext())
            {
                Inspector insp = db.Inspectors.Find(inspector.InspectorId);

                insp.InspectorNumber = inspector.InspectorNumber;
                insp.InspectorName = inspector.InspectorName;

                List<Inspection> inspections = db.Inspections.Where<Inspection>(i => i.InspectorId == inspector.InspectorId).ToList();

                for(int i = 0; i < inspections.Count; i++)
                {
                    inspections[i].InspectorName = inspector.ToString();
                }

                db.SaveChanges();
            }
        }

    }
}
