using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHI_API.Models.Inspections {

	public class Data {
		public Inspection Inspection { get; set; }
	}

	public class Inspection {
		public Guid InspectionID { get; set; }
		public string Status { get; set; }		
		public string ClientName { get; set; }
		public Address ClientAddress { get; set; }
		public Address DwellingAddress { get; set; }
		public string DocumentType { get; set; }
		public string ClientAgent { get; set; }
		public string DocumentNumber { get; set; }
		public DateTime DateAssigned { get; set; }
		public DateTime DateScheduled { get; set; }
		public DateTime? DateSynced { get; set; }
		public DateTime? DateCompleted { get; set; }
		public Int32? InspectionArea { get; set; }
		public string RealEstateCompany { get; set; }
		public string LegalText { get; set; }
		public string DefinitionOfTerms { get; set; }
		public string FooterText { get; set; }
		public string SummaryDisclaimer { get; set; }
		public Attachment[] Attachments { get; set; }
		public Inspector[] Inspectors { get; set; }
		public Category[] Categories { get; set; }
	}

	public class Address {
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
	}

	public class Attachment {
		public Guid AttachmentID { get; set; }
		public Int32 SortOrder { get; set; }
	}

	public class Inspector {
		public Guid UserID { get; set; }
	}

	public class Category {
		public Guid CategoryID { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public string Status { get; set; }
		public bool DisplayCategoryOnReport { get; set; }
		public bool DisplayCategoryCommentOnSummaryReport { get; set; }
		public Attachment[] Attachments { get; set; }
		public Step[] Steps { get; set; }
	}

	public class Step {
		public Guid StepID { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public string Status { get; set; }
		public bool DisplayOnReport { get; set; }
		public Attachment[] Attachments { get; set; }
		public Material[] Materials { get; set; }
		public Comment[] Comments { get; set; }
		public Rating[] Ratings { get; set; }
	}

	public class Material {
		public Guid MaterialID { get; set; }
		public string Description { get; set; }
		public string Text { get; set; }
		public bool IsSelected { get; set; }
		public bool DisplayOnFullReport { get; set; }
		public bool DisplayOnSummaryReport { get; set; }
		public Attachment[] Attachments { get; set; }
		public Picker[] Pickers { get; set; }
	}

	public class Picker {
		public Guid PickerID { get; set; }
		public string Keyword { get; set; }
		public Option[] Options { get; set; }
	}

	public class Option {
		public string Value { get; set; }
		public bool IsSelected { get; set; }
	}

	public class Comment {
		public Guid CommentID { get; set; }
		public string Description { get; set; }
		public string Text { get; set; }
		public bool IsSelected { get; set; }
		public bool DisplayOnFullReport { get; set; }
		public bool DisplayOnSummaryReport { get; set; }
		public Attachment[] Attachments { get; set; }
		public Picker[] Pickers { get; set; }
	}

	public class Rating {
		public Guid RatingID { get; set; }
		public string Text { get; set; }
		public bool IsSelected { get; set; }
		public bool OverrideDisplayOnFullReport { get; set; }
		public bool OverrideDisplayOnSummaryReport { get; set; }
	}
}