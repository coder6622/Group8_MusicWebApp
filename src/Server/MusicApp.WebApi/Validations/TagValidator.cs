using MusicApp.WebApi.Models.Tags;
using FluentValidation;

namespace MusicApp.WebApi.Validations
{
    public class TagValidator : AbstractValidator<TagEditModel>
    {
        public TagValidator() 
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Tên Tag sĩ không được để trống!!!!!")
                .MaximumLength(100)
                .WithMessage("Tên Tag tối đa 100 ký tự :3");

            RuleFor(a => a.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug không được để trống!!!!!")
                .MaximumLength(100)
                .WithMessage("UrlSlug tối đa 100 ký tự :3");

            RuleFor(a => a.Description)
                .MaximumLength(1000)
                .WithMessage("Mô tả tối đa 1000 ký tự :3");

           
        }
    }
}
