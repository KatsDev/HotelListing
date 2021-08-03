using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class CountryDto : CreateCountryDto
    {
        public int Id { get; set; }
        public IList<HotelDto> Hotels { get; set; }
    }

    public class CreateCountryDto
    {
        [Required(ErrorMessage = "Country Name Is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "Country Name Is Too Long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short Country Name Is Required")]
        [StringLength(maximumLength: 3, ErrorMessage = "Short Country Name Is Too Long")]
        public string ShortName { get; set; }
    }

    public class UpdateCountryDto : CreateCountryDto
    {
        public IList<CreateHotelDto> Hotels { get; set; }
    }
}
