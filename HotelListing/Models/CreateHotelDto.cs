using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CreateHotelDto
    {
        [Required(ErrorMessage = "Country Name Is Required")]
        [StringLength(maximumLength: 200, ErrorMessage = "Country Name Is Too Long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address Is Required")]
        [StringLength(maximumLength: 200, ErrorMessage = "Address Is Too Long")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Rating Is Required")]
        [Range(1,5)]
        public double Rating { get; set; }

        //[Required(ErrorMessage = "Country Is Required")]
        public int CountryId { get; set; }
    }

    public class HotelDto : CreateHotelDto
    {
        public int Id { get; set; }
        public CountryDto Country { get; set; }
    }

    public class UpdateHotelDto : CreateHotelDto
    {

    }
}
