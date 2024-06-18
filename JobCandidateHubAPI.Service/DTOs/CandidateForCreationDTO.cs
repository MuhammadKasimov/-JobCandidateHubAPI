using JobCandidateHubAPI.Service.Validations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Service.DTOs
{
    public class CandidateForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        
        public DateTime TimeForCall { get; set; }
        
        [LinkedIn]
        public string LinkedInUrl { get; set; }
        [Github]
        public string GithubUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
