using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Interface
{
    interface IUserContext: IMainContext
    {
        int tryLogin(string username, string password);
    }
}
