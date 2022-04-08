using HakunaMatata.Models;
using HakunaMatata.Repositories;

namespace HakunaMatata.Services
{
    public class UserServices
    {
        private UserRepository _repository;

        public UserServices(UserRepository repository)
        {
            _repository = repository;
        }

        public bool LogIn(string email, string password)
        {
            foreach (var user in _repository)
            {
                if (user.Email.Equals(email) && user.Password.Equals(password))
                    return true;
            }

            return false;
        }

        public bool Register(string email, string password, string firstName, string lastName)
        {
            foreach (var user in _repository)
            {
                if (user.Email.Equals(email))
                    return false;
            }

            var id = _repository.Last().Id + 1;
            _repository.Add(new User { Id = id, Email = email, Password = password, FirstName = firstName, LastName = lastName });
            return true;
        }
    }
}
