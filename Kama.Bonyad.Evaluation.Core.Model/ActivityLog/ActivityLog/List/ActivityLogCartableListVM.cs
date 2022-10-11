using Kama.Organization.Core.Model;
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
    public class ActivityLogListVM : ListVM
    {
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        public string UserIP { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Guid? ControllerID { get; set; }
        public string ControllerName { get; set; }
        public Guid? ActionID { get; set; }
        public string ActionName { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OS OS { get; set; }
        public Browser Browser { get; set; }
        public string DepartmentName { get; set; }
        public DeviceType DeviceType { get; set; }
        public Guid? ObjectID { get; set; }
        public int Total { get; set; }
        public bool? Success { get; set; }
        public Guid? PositionID { get; set; }
    }
}
