
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
    public class EntryViewModel
    {
        [Required (AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required (AllowEmptyStrings = false)]
        [DataType(DataType.Text)]        
        public string FirstName { get; set; }

        [Required (AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
