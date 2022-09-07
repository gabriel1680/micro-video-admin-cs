using FC.Codeflix.Catalog.Domain.Kernel.Entity;

namespace FC.Codeflix.Catalog.Domain.Kernel.Repository;

public interface IDefaultRepository<E> : 
    ICreateRepository<E>, 
    IUpdateRepository<E>, 
    IFindByIdRepository<E>, 
    IDeleteRepository  
    where E : IEntity { }