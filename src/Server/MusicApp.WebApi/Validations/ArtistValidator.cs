using FluentValidation;
using MusicApp.WebApi.Models.Artist;

namespace MusicApp.WebApi.Validations
{
    public class ArtistValidator : AbstractValidator<ArtistEditModel>
    {
        public ArtistValidator() 
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .WithMessage("Tên Tác giả/ca sĩ không được để trống!!!!!")
                .MaximumLength(100)
                .WithMessage("Tên tác giả tối đa 100 ký tự :3");

            RuleFor(a => a.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug không được để trống!!!!!")
                .MaximumLength(100)
                .WithMessage("UrlSlug tối đa 100 ký tự :3");

            RuleFor(a => a.DayOfBirth)
                .GreaterThan(DateTime.MinValue)
                .WithMessage("Ngày sinh không hợp lệ :(");

            RuleFor(a => a.Gender)
                .NotEmpty()
                .WithMessage("Bạn phải chọn giới tính @@");

            RuleFor(a => a.Nation)
                .NotEmpty()
                .WithMessage("Dân tộc không được để trống!!!!!")
                .MaximumLength(50)
                .WithMessage("Dân tộc tối đa 50 ký tự :3");

            RuleFor(a => a.Information)
                .MaximumLength(1000)
                .WithMessage("Thông tin của ca sĩ tối đa 1000 ký tự :3");

        }
    }
}
