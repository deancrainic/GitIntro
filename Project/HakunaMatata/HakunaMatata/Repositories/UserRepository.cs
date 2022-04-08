using HakunaMatata.Models;

namespace HakunaMatata.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(List<User> repository) : base(repository)
        {
        }

        public int IndexOf(string email)
        {
            foreach (var user in _repository)
            {
                if (user.Email.Equals(email))
                    return _repository.IndexOf(user);
            }

            return -1;
        }
    }
}
