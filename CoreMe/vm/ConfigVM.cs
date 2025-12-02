using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CoreMe.VM
{
    public class GetConfigVM :  IValidatableObject
    {
        [DefaultValue("Key")]
        public string Key { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Key) )
            {
                yield return new ValidationResult(
                    " Enter the key.",
                    new[] { nameof(Key)}
                );
            }
        }
    }


}