using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHI_API.Models.Attachments {

	public class Data {
		public Attachment Attachment { get; set; }
	}

	public class Attachment {
		public Guid AttachmentID { get; set; }
		public string Data { get; set; }
		public string Type { get; set; }
		public Int32 Size { get; set; }
		public string Description { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdated { get; set; }
		public DateTime DateSynced { get; set; }
	}
}