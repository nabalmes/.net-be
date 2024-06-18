using AspNetCoreHero.Abstractions.Domain;
using Microsoft.VisualBasic;
using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace SampleBackEndTemplate.Domain.Entities.GymManagement
{
    public class Members : AuditableEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        //public string MemberCode { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateStartedAsAMember { get; set; }
        public DateTime ValidityDateOfMembership { get; set; }
        public bool IsRenewed { get; set; }
        public bool IsContractSigned { get; set; }
        public bool IsPaid { get; set; }
        public string TrainerName { get; set; }
    }
}