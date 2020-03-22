using Entities.FatherEntity;
using Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Entities.Entities
{
    public class Admin : Entity
    {
        public Admin()
        {

        }
        public Admin(string name, Login login, DateTime bornDate)
        {
            AddNotifications(new Contract()
                .Requires()

                .HasMinLen(login.Email, 11, "Admin.Login.Email", "O Email do admin não pode ser menor que 11 caracteres")
                .HasMaxLen(login.Email, 70, "Admin.Login.Email", "O Email do admin não pode ser maior que 70 caracteres")

                .HasMinLen(login.Password, 8, "Admin.Login.Password", "A senha do admin não pode ser menor que 8 caracteres")
                .HasMaxLen(login.Password, 16, "Admin.Login.Password", "A senha do admin não pode ser menor que 16 caracteres")

                .IsGreaterOrEqualsThan(bornDate, DateTime.UtcNow, "Admin.BornDate", "A data de nascimento do usuario é invalida")
                .IsLowerThan(bornDate, DateTime.Now.AddYears(-120), "Admin.BornDate", "A data de nascimento do usuario é invalida")
                );
                
            if(BornDate.AddYears(18) < DateTime.Now)
            {
                AddNotification("Admin.BornDate", "O usuario deve ter pelo menos 18 anos para ser um admin");
            }
                
            Name = name;
            Login = login;
            BornDate = bornDate;
        }

        public string Name { get; private set; }
        public Login Login { get; private set; } 
        public DateTime BornDate { get; private set; }
    }
}
