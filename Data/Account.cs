using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATMSystem
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string PinHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Balance { get; set; }
    }
}
