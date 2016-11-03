using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHI_API.Models.Companies {

	public class Data {
		public Company Company { get; set; }
	}

	public class Company {
		public Guid CompanyID { get; set; }
		public string Name { get; set; }
		public string DBAName { get; set; }
		public Address MailingAddress { get; set; }
		public Address DeliveryAddress { get; set; }
		public Phone OfficePhone { get; set; }
		public Phone FaxPhone { get; set; }
		public string URL { get; set; }
	}

	public class Address {
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
	}

	public class Phone {
		public string Number { get; set; }
	}
}