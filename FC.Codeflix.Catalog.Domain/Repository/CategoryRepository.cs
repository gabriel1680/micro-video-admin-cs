using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.Repository;

namespace FC.Codeflix.Catalog.Domain.Repository;

public interface ICategoryRepository : IDefaultRepository<Category>
{
}