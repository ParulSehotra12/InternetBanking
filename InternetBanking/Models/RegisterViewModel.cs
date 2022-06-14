using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class RegisterViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestID { get; set; }
        [Required(ErrorMessage = "Enter SBAccountNumber !")]

        [Display(Name = "Enter SBAccountNumber :")]
        [StringLength(maximumLength: 12, MinimumLength = 12, ErrorMessage = "SBAccountNumber length must be 12")]
        public string SBAccountNumber { get; set; }

        [Required(ErrorMessage = "Enter CIFNumber !")]
        [Display(Name = "Enter CIFNumber :")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "CIFNumber length must be 11")]
        public string CIFNumber { get; set; }

        [Required(ErrorMessage = "Enter BranchCode !")]
        [Display(Name = "Enter BranchCode :")]
        [StringLength(maximumLength: 12, MinimumLength = 7, ErrorMessage = "BranchCode length must be between 7-12")]
        public string BranchCode { get; set; }

        [Required(ErrorMessage = "Enter RegistereedMobileNumber !")]
        [Display(Name = "Enter RegisteredMobileNumber :")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "RegisteredMobileNo length must be 10")]
        public string RegisteredMobileNo { get; set; }
        public int UStatus { get; set; }
    }
}








