using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHI_API.Models.Users {

	public class Data {
		public User User { get; set; }
	}

	public class User {
		public Guid UserID { get; set; }
		public Guid? SessionID { get; set; }
		public Guid? AuthenticationKey { get; set; }
		public Guid? CompanyID { get; set; }
		public DateTime? DateLastLogin { get; set; }
		public DateTime? DateSynced { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Language { get; set; }
		public string PictureAlignment { get; set; }
		public string InspectionTemplateID { get; set; }
		public string ReportTemplateID { get; set; }
	}
}