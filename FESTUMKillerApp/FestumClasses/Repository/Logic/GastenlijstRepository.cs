using FestumClasses.Objects;
using FestumClasses.Repository.Context;
using FestumClasses.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Logic
{
    public class GastenlijstRepository
    {
        private IGastenlijstContext context;

        public GastenlijstRepository()
        {
            this.context = new GastenlijstSQLContext();
        }

        public List<User> getAllGastenlijst(int feestId)
        {
            return this.context.getAllValues(feestId).Cast<User>().ToList();
        }

        public object getGastenlijst(int id)
        {
            return (object)this.context.getValue(id);
        }

        public void saveGastenlijst(int userId, int feestId)
        {
            this.context.saveValue(userId, feestId);
        }

        public void deleteGastenlijst(int userId, int feestId)
        {
            this.context.deleteValue(userId, feestId);
        }
    }
}
