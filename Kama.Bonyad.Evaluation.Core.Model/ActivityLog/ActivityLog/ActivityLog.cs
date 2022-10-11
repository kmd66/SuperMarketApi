
using Kama.Organization.Core.Model;
using System;

namespace Kama.Bonyad.Evaluation.Core.Model
{
   public class ActivityLog : Model
    {
        public DateTime CreationDate { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public Guid? PositionID { get; set; }
        public string UserFullName { get; set; }
        Organization.Core.Model.PositionType PositionType { get; set; }
        public UserType UserType { get; set; }
        public string UserIP { get; set; }
        public string CreationTime => CreationDate.ToString("HH:mm:ss");
        public string Time { get; set; }
        public string ControllerTitle { get; set; }
        public string ActionTitle { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OS OS { get; set; }
        public string OSVersion { get; set; }
        public string OsTitle => $"{OS.ToString()} {OSVersion}";
        public string BrowserTitle => $"{Browser.ToString()} {BrowserVersion}";
        public Browser Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string DepartmentName { get; set; }
        public bool Success { get; set; }
        public DeviceType DeviceType { get; set; }
        public int? ObjectID { get; set; }
        public object Object { get; set; }
        public int Total { get; set; }
    }
}
