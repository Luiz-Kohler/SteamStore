using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class UserValidate : User
    {
        public IReadOnlyCollection<Notification> ValidateUserToCreat(User User)
        {
            Contract UserValidating = new Contract()
            .Requires()

            .HasMinLen(User.Nick, 1, "User.Nick", "O nick do usuario deve conter pelo menos 1 caractere")

            .HasMinLen(User.Login.Email, 11, "User.Login.Email", "O Email do usuario não pode ser menor que 11 caracteres")
            .HasMaxLen(User.Login.Email, 70, "User.Login.Email", "O Email do usuario não pode ser maior que 70 caracteres")

            .HasMinLen(User.Login.Password, 8, "User.Login.Password", "A senha do usuario não pode ser menor que 8 caracteres")
            .HasMaxLen(User.Login.Password, 16, "User.Login.Password", "A senha do usuario não pode ser menor que 16 caracteres")

            .IsGreaterOrEqualsThan(User.BornDate, DateTime.UtcNow, "User.BornDate", "A data de nascimento do usuario é invalida")
            .IsLowerThan(User.BornDate, DateTime.Now.AddYears(-120), "User.BornDate", "A data de nascimento do usuario é invalida");

            return UserValidating.Notifications;

        }
    }
}
