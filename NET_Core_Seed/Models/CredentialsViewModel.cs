using NET_Core_Seed.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentValidation.Attributes;

namespace NET_Core_Seed.Models
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
