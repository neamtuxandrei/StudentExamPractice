using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExamPracticeBE.Domain
{
    public abstract class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public void SetName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("The name must not be empty", "firstName");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("The name must not be empty", "lastName");
            FirstName = firstName;
            LastName = lastName;
        }
        public void SetEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("The email must not be empty", "emailAddress");
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("");
            EmailAddress = emailAddress;
        }

    }
}
