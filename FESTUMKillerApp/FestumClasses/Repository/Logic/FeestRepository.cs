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
    public class FeestRepository
    {
        private IMainContext context;

        public FeestRepository()
        {
            this.context = new FeestSQLContext();
        }

        public List<Feest> getAllFeesten()
        {
            return this.context.getAllValues().Cast<Feest>().ToList();
        }

        public Feest getFeest(int id)
        {
            return (Feest)this.context.getValue(id);
        }

        public void saveFeest(Feest feest)
        {
            this.context.saveValue(feest);
        }

        public void deleteFeest(int id)
        {
            this.context.deleteValue(id);
        }
    }
}
