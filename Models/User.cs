using System.ComponentModel.DataAnnotations;

namespace Auth_mvc.Models
{
    public class User
    {
            [Key]
            public Guid UserId { get; set; }
            public string? UserName { get; set; }

            [DataType(DataType.Password)]
            public string? Password { get; set; }
            public bool IsActione { get; set; }
            public DateTime CreateAt { get; set; }
        
    }
}
