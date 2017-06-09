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
    public class UserRepository
    {
        private IUserContext context;

        public UserRepository()
        {
            this.context = new UserSQLContext();
        }

        public List<User> getAllUsers()
        {
            return this.context.getAllValues().Cast<User>().ToList();
        }

        public User getUser(int id)
        {
            return (User)this.context.getValue(id);
        }

        public void saveUser(User user, string wachtwoord)
        {
            this.context.saveValue(user, wachtwoord);
        }

        public void saveUser(User user)
        {
            this.context.saveValue(user);
        }

        public void deleteUser(int id)
        {
            this.context.deleteValue(id);
        }

        public int tryLogin(string username, string password)
        {
            return this.context.tryLogin(username, password);
        }

        public bool checkUsernameUnique(string gebruikersnaam)
        {
            return this.context.checkUsernameUnique(gebruikersnaam);
        }

        public int getUserId(string gebruikersnaam)
        {
            return this.context.getUserId(gebruikersnaam);
        }
    }
}
