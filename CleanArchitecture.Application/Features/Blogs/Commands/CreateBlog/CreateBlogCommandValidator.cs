using FluentValidation;
namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(20).WithMessage("max is 20");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.")
                 .MaximumLength(50).WithMessage("max is 50"); ;
        }
    }
}
