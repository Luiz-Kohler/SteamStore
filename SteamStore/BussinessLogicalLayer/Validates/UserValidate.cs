using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class UserValidate : User, IBaseValidate<User>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(User objectToValidate)
        {
            Contract ValidatingUser = new Contract()
            .Requires()

            .HasMinLen(objectToValidate.Nick, 1, "User.Nick", "O nick do usuario deve conter pelo menos 1 caractere")

            .IsNotNull(objectToValidate.Login, "User.Login", "O login não pode ser nulo")

            .HasMinLen(objectToValidate.Login.Email, 11, "User.Login.Email", "O Email do usuario não pode ser menor que 11 caracteres")
            .HasMaxLen(objectToValidate.Login.Email, 70, "User.Login.Email", "O Email do usuario não pode ser maior que 70 caracteres")

            .HasMinLen(objectToValidate.Login.Password, 8, "User.Login.Password", "A senha do usuario não pode ser menor que 8 caracteres")
            .HasMaxLen(objectToValidate.Login.Password, 16, "User.Login.Password", "A senha do usuario não pode ser menor que 16 caracteres")

            .IsGreaterOrEqualsThan(objectToValidate.BornDate, DateTime.UtcNow, "User.BornDate", "A data de nascimento do usuario é invalida")
            .IsLowerThan(objectToValidate.BornDate, DateTime.Now.AddYears(-120), "User.BornDate", "A data de nascimento do usuario é invalida");

            return ValidatingUser.Notifications;
        }
    }
}
