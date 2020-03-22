using Entities.FatherEntity;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Comment : Entity
    {

        public Comment()
        {

        }
        public Comment(string message, Guid writterID, Guid forUserID)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(message, 1, "Comment.Message", "O comentario não pode ser menor que 11 caracteres")
                .HasMaxLen(message, 100, "Comment.Message", "O comentario não pode ser maior que 100 caracteres")
                );

            Message = message;
            DateTimeComment = DateTime.UtcNow;
            WritterID = writterID;
            ForUserID = forUserID;
        }

        public string Message { get; private set; }
        public DateTime DateTimeComment { get; private set; }
        public Guid WritterID { get; private set; }
        public virtual User Writter { get; private set; }
        public Guid ForUserID { get; private set; }
        public virtual User ForUser { get; private set; }

        public void GetUserWritter(User userWritter)
        {
            this.Writter = userWritter;
        }

        public void GetForUser(User forUser)
        {
            this.ForUser = forUser;
        }
    }
}
