using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Interface
{
    interface IMainContext
    {
        object getValue(int id);
        void saveValue(object value);
        List<object> getAllValues();
        void deleteValue(object value);
    }
}
