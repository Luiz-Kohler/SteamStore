using BussinessLogicalLayer.Validates.Interface;
using Entities.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicalLayer.Validates
{
    public class CommentValidate : Comment, IBaseValidate<Comment>
    {
        public IReadOnlyCollection<Notification> ValidateObjectToCreat(Comment objectToValidate)
        {
            Contract ValidatingAd = new Contract()
            .Requires()
            .HasMinLen(objectToValidate.Message, 1, "Comment.Message", "O comentario não pode ser menor que 11 caracteres")
            .HasMaxLen(objectToValidate.Message, 100, "Comment.Message", "O comentario não pode ser maior que 100 caracteres");

            return ValidatingAd.Notifications;
        }
    }
}
