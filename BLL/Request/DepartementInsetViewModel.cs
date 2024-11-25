using FluentValidation;

namespace BLL.Request;

public class DepartementInsetViewModel
{
    public int DepartementId { get; set; }
    public String Name { get; set; }
    public String Code { get; set; }

}

public class DepartementInsetViewModelValidadator : AbstractValidator<DepartementInsetViewModel>
{
    public DepartementInsetViewModelValidadator() {
      RuleFor(x => x.DepartementId).NotNull().NotEmpty();
      RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(4).MaximumLength(25);
      

    }
}
