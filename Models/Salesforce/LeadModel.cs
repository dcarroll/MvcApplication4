using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Common.Attributes;

namespace MvcApplication4.Models.Salesforce
{
    public class Lead
    {
        [Key]
        [Updateable(false)]
        [Createable(false)]
        public string Id { get; set; }

        [Createable(true)]
        [Updateable(true)]
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Salutation { get; set; }

        [Createable(false)]
        [Updateable(false)]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Phone]
        public string MobilePhone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Industry { get; set; }

        [Createable(false)]
        [Updateable(false)]
        public DateTimeOffset CreatedDate { get; set; }

        [Createable(false)]
        [Updateable(false)]
        public DateTimeOffset LastModifiedDate { get; set; }

    }
}
