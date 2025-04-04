using AdvancedProgramming.Data;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
    }

    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        public RepositoryCategory() : base()
        {
        }

        // Implement any specific methods for Product if needed
    }

}
