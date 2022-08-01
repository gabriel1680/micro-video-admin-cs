using FC.CodeFlix.Catalog.Application;
using FC.CodeFlix.Catalog.Application.UseCase.Category.Create;
using FC.CodeFlix.Catalog.Application.UseCase.Category.Create.DTO;
using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Kernel.Repository;

using Moq;

namespace FC.Codeflix.Catalog.UnitTests.Application.UseCase.CreateCategory;

public class CreateCategoryUseCaseTest
{
    [Fact(DisplayName = nameof(Execute))]
    [Trait("Application", "CreateCategory - Use Case")] 
    public async void Execute()
    {
        var repository = new Mock<ICreateRepository<Category>>();
        var unitOfWork = new Mock<IUnitOfWork>();
        var useCase = new CreateCategoryUseCase(repository.Object, unitOfWork.Object);
        var input = new CreateCategoryInput("A Name", "A Description");

        var output = await useCase.Execute(input, CancellationToken.None);

        Assert.IsType<CreateCategoryOutput>(output);
        
        repository.Verify(
            repo => repo.Create(
                It.IsAny<Category>(), 
                It.IsAny<CancellationToken>()
            ), 
            Times.Once
        );
        unitOfWork.Verify(
            uot => uot.Commit(
                It.IsAny<CancellationToken>()
            ), 
            Times.Once
        );
    }
}