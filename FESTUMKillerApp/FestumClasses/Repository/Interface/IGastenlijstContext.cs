using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Interface
{
    interface IGastenlijstContext
    {
        object getValue(int id);
        void saveValue(int userId, int feestId);
        List<object> getAllValues(int feestId);
        void deleteValue(int userId, int feestId);
    }
}
