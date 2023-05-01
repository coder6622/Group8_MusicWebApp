using MusicApp.WebApi.Models.GroupTag;
using FluentValidation;

namespace MusicApp.WebApi.Validations
{
    public class GroupTagValidator : AbstractValidator<GroupTagEditModel>
    {
        public GroupTagValidator() 
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .WithMessage("Tên GrTag không được để trống!!!!!")
               .MaximumLength(100)
               .WithMessage("Tên BrTag tối đa 100 ký tự :3");

            RuleFor(a => a.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug không được để trống!!!!!")
                .MaximumLength(100)
                .WithMessage("UrlSlug tối đa 100 ký tự :3");
        }
    }
}
