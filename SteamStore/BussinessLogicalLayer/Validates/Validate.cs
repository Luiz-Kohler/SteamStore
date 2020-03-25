using Entities.Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BussinessLogicalLayer.Validates
{
    public static class Validate
    {
        public static Response AdValidate(bool verifyId, Ad ad)
        {
            Response response = new Response();

            if (ad.Price <= 0)
            {
                response.Erros.Add(new Error { Proprety = "Price", Message = "O valor do item não pode ser igual ou menor que zero" });
            }

            if (ad.ItemID == null)
            {
                response.Erros.Add(new Error { Proprety = "ItemID", Message = "O anuncio precisa ser informado para criar o anuncio" });
            }

            if (ad.IsSold)
            {
                response.Erros.Add(new Error { Proprety = "IsSold", Message = "O anuncio não pode ser criado como vendido" });
            }

            if (verifyId && ad.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "ID invalido" });
            }

            return response;
        }

        public static Response CommentValidate(bool verifyId, Comment comment)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(comment.Message))
            {
                response.Erros.Add(new Error { Proprety = "Message", Message = "Você deve comentar alguma coisa" });
            }

            if (comment.ForUserID == null)
            {
                response.Erros.Add(new Error { Proprety = "ForUserID", Message = "O usuario que você deseja comentar não é valido" });
            }

            if (comment.WritterID == null)
            {
                response.Erros.Add(new Error { Proprety = "WritterID", Message = "O usuario que esta comentando isso não é valido" });
            }

            if (verifyId && comment.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "ID invalido" });
            }

            return response;
        }

        public static Response FriendValidate(bool verifyId, Friend friend)
        {
            Response response = new Response();

            if (friend.UserID == null)
            {
                response.Erros.Add(new Error { Proprety = "UserID", Message = "O ID do usuario esta invalido" });
            }

            if (friend.FriendUserID == null)
            {
                response.Erros.Add(new Error { Proprety = "RequestUserID", Message = "O ID do amigo do usuarip é invalido" });
            }

            if (verifyId && friend.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "O ID não é valido" });
            }

            return response;
        }

        public static Response FriendRequestValidate(bool verifyId, FriendRequest friendRequest)
        {
            Response response = new Response();

            if (friendRequest.RequestUserID == null)
            {
                response.Erros.Add(new Error { Proprety = "ForUserID", Message = "O ID do usuario que você esta mandando este convite é invalido" });
            }

            if (friendRequest.RequestUserID == null)
            {
                response.Erros.Add(new Error { Proprety = "RequestUserID", Message = "O ID do usuario que esta enviando este convite é invalido" });
            }

            if (verifyId && friendRequest.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "O ID não é valido" });
            }

            return response;
        }

        public static Response ItemValidate(bool verifyId, Item item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                response.Erros.Add(new Error { Proprety = "Name", Message = "O nome do item deve ser informado" });
            }
            else
            {
                item.ChangeName(item.Name);
                if (item.Name.Length < 2 || item.Name.Length > 60)
                {
                    response.Erros.Add(new Error { Proprety = "Name", Message = "O nome do item deve conter entre 2 a 60 caracteres" });
                }
            }

            if (item.UserID == null)
            {
                response.Erros.Add(new Error { Proprety = "UserID", Message = "O item tem que ter um dono" });
            }

            if (verifyId && item.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "ID invalido" });
            }

            return response;
        }

        public static Response SaleValidate(bool verifyId, Sale sale)
        {
            Response response = new Response();

            if (sale.AdId == null)
            {
                response.Erros.Add(new Error { Proprety = "AdId", Message = "A venda precisa de um anuncio valido" });
            }

            if (sale.BuyerId == null)
            {
                response.Erros.Add(new Error { Proprety = "BuyerId", Message = "A venda precisa de um comprador valido" });
            }

            if (verifyId && sale.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "ID invalido" });
            }
            return response;
        }

        public static Response ValidateLoginUser(string Email, string Password)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(Email))
            {
                response.Erros.Add(new Error { Proprety = "Email", Message = "Digite um email" });
            }
            else
            {

               
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(Email);

                if (!match.Success)
                {
                    response.Erros.Add(new Error { Proprety = "Email", Message = "Digite um Email valido" });
                }

                Email = Regex.Replace(Email, @"\s+", " ");
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                response.Erros.Add(new Error { Proprety = "Password", Message = "Digite uma senha" });
            }
            else
            {

                Regex hasNumber = new Regex(@"[0-9]+");
                Regex hasUpperChar = new Regex(@"[A-Z]+");
                Regex hasLowerChar = new Regex(@"[a-z]+");

                if (Password.Length < 4 || Password.Length > 16)
                {
                    response.Erros.Add(new Error { Proprety = "Password", Message = "A senha deve conter entre 4 a 16 caracteres" });
                }

                if (!hasLowerChar.IsMatch(Password))
                {
                    response.Erros.Add(new Error { Proprety = "Password", Message = "A senha deve conter uma letra minuscula" });
                }

                if (!hasUpperChar.IsMatch(Password))
                {
                    response.Erros.Add(new Error { Proprety = "Password", Message = "A senha deve conter uma letra maiuscula" });
                }

                if (!hasNumber.IsMatch(Password))
                {
                    response.Erros.Add(new Error { Proprety = "Password", Message = "A senha deve conter um numero" });
                }
            }

            return response;
        }


        public static Response UserValidate(bool verifyId, User user)

        {
            Response response = ValidateLoginUser(user.Login.Email, user.Login.Password);

            if (string.IsNullOrWhiteSpace(user.Nick))
            {
                response.Erros.Add(new Error { Proprety = "Nick", Message = "Digite um nick valido" });
            }
            else
            {
                user.ChangeNick(user.Nick);

                if (user.Nick.Length < 2 || user.Nick.Length > 20)
                {
                    response.Erros.Add(new Error { Proprety = "Nick", Message = "O nick deve conter entre 2 a 20 caracteres" });
                }
            }

            if (user.BornDate.Date > DateTime.Now.Date || (DateTime.Now.Date.Year - user.BornDate.Year) > 120)
            {
                response.Erros.Add(new Error { Proprety = "BornDate", Message = "Informe uma data de nascimento valida" });
            }
            else if ((DateTime.Now.Date - user.BornDate.Date) < new TimeSpan(365, 0, 0, 0))
            {
                response.Erros.Add(new Error { Proprety = "BornDate", Message = "O usuario deve conter 18 anos para se cadastrar" });
            }

            if (verifyId && user.ID == null)
            {
                response.Erros.Add(new Error { Proprety = "ID", Message = "ID invalido" });
            }
            return response;
        }
    }
}
