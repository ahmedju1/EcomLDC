using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Users.User.DataModels
{
    public record UserDto(Guid Id, string Username, string Email, string Role);
    // record msh hayb2a 3ndo methods zay al classes, bas hayb2a 3ndo constructor w properties bas
    // mnrg3sh object lluser min domian bas nrga3 object bsita w safe

}
