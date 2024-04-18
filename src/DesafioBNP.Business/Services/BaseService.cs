using DesafioBNP.Business.Intefaces;
using DesafioBNP.Business.Models;
using DesafioBNP.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DesafioBNP.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _Notificator;

        protected BaseService(INotificator Notificator)
        {
            _Notificator = Notificator;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _Notificator.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if(validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}