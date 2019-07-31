

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CCode.Files;

namespace CCode.Files.Dtos
{
    public class CreateOrUpdateFileInput
    {
        [Required]
        public FileEditDto File { get; set; }

    }
}