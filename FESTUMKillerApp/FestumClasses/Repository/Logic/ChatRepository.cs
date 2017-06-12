using FestumClasses.Repository.Context;
using FestumClasses.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestumClasses.Repository.Logic
{
    public class ChatRepository
    {
        private IMainContext context;

        public ChatRepository()
        {
            this.context = new ChatSQLContext();
        }

        public List<object> getAllChats()
        {
            return this.context.getAllValues().Cast<object>().ToList();
        }

        public object getChat(int id)
        {
            return (object)this.context.getValue(id);
        }

        public void saveBericht(string bericht)
        {
            this.context.saveValue(bericht);
        }

        public void deleteChat(int id)
        {
            this.context.deleteValue(id);
        }
    }
}
