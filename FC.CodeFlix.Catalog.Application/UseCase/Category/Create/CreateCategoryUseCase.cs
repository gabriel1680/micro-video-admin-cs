using FC.CodeFlix.Catalog.Application.Kernel.UseCase;
using FC.CodeFlix.Catalog.Application.UseCase.Category.Create.DTO;
using FC.Codeflix.Catalog.Domain.Kernel.Repository;

namespace FC.CodeFlix.Catalog.Application.UseCase.Category.Create;

using FC.Codeflix.Catalog.Domain.Entity;

public class CreateCategoryUseCase : IGenericUseCase<CreateCategoryInput, CreateCategoryOutput>
{
    private readonly ICreateRepository<Category> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryUseCase(ICreateRepository<Category> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCategoryOutput> Execute(CreateCategoryInput input, CancellationToken cancellationToken)
    {
        var category = new Category(input.Name, input.Description, input.IsActive);
        await _repository.Create(category, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        return new CreateCategoryOutput(category.Id.Value);
    }
}