using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal_Web
{
	public class PersonDetails
	{
		public string personFirstName,personPhoneNumber, persongender,personLastName, personAddress, personEmail, personPassword, personRole;
		public long personUserId;
		
		public PersonDetails(string FirstName,string phone, string LastName, string Address, string Password, string Gender,string Role, string Email, long userId)
		{
			this.personAddress = Address;
			this.personEmail = Email;
			this.personFirstName = FirstName;
			this.personLastName = LastName;
			this.personPassword = Password;
			this.personRole = Role;
			this.personUserId = userId;
			this.persongender = Gender;
			this.personPhoneNumber = phone;

		}
	}

}
