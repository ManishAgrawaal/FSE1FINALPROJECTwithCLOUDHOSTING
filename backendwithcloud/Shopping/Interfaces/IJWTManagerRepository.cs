using LoginServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginServices.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(LoginViewModel users);
        
    }
}
