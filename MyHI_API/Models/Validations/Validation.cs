using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHI_API.Models.Validations {

	public class Data {
		public Validation Validation { get; set; }
	}

	public class Validation {
		public string ValidationID { get; set; }
		public Item[] Items { get; set; }
	}

	public class Item {
		public string Name { get; set; }
		public string[] Value { get; set; }
	}
}