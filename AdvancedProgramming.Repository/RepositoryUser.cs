using AdvancedProgramming.Data;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
    }

    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser() : base()
        {
        }

        // Implement any specific methods for Product if needed
    }

}
