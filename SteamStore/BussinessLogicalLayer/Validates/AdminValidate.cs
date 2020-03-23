using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    class AdminValidate : Admin, IBaseValidate<Admin>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(Admin objectToValidate)
        {
            Contract ValidatingAdmin = new Contract()
                 .Requires()

                .HasMinLen(objectToValidate.Login.Email, 11, "Admin.Login.Email", "O Email do admin não pode ser menor que 11 caracteres")
                .HasMaxLen(objectToValidate.Login.Email, 70, "Admin.Login.Email", "O Email do admin não pode ser maior que 70 caracteres")

                .HasMinLen(objectToValidate.Login.Password, 8, "Admin.Login.Password", "A senha do admin não pode ser menor que 8 caracteres")
                .HasMaxLen(objectToValidate.Login.Password, 16, "Admin.Login.Password", "A senha do admin não pode ser menor que 16 caracteres")

                .IsGreaterOrEqualsThan(objectToValidate.BornDate, DateTime.UtcNow, "Admin.BornDate", "A data de nascimento do usuario é invalida")
                .IsLowerThan(objectToValidate.BornDate, DateTime.Now.AddYears(-120), "Admin.BornDate", "A data de nascimento do usuario é invalida");

            if (BornDate.AddYears(18) < DateTime.Now)
            {
                ValidatingAdmin.AddNotification("Admin.BornDate", "O usuario deve ter pelo menos 18 anos para ser um admin");
            }

            return ValidatingAdmin.Notifications;
        }
    }
}
