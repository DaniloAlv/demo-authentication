using System;
using System.Collections.Generic;
using System.Linq;
using AuthDemo.DTOs;
using AuthDemo.Models;

namespace AuthDemo.Repositories
{
    public static class UserRepository
    {
        public static User GetUser(UserLoginDto userlogin)
        {
            return GetUsers()
                .FirstOrDefault(user => user.Email == userlogin.Email && user.Password == userlogin.Password);
        }

        private static IList<User> GetUsers()
        {
            return new List<User>{
                new(){
                    Id = Guid.NewGuid(),
                    Name = "Shiryu",
                    Email = "shiryu_rozan@cdz.com",
                    Password = "cincoPicosRozan",
                    Roles = new string[]{
                        "Lendario",
                        "Ouro"
                    }
                },
                new(){
                    Id = Guid.NewGuid(),
                    Name = "Myu",
                    Email = "papylon@cdz.com",
                    Password = "brabuletas",
                    Roles = new string[]{
                        "Espectro"
                    }
                },
                new(){
                    Id = Guid.NewGuid(),
                    Name = "Orfeu",
                    Email = "orfeu_da_lira@cdz.com",
                    Password = "prataMaisPica",
                    Roles = new string[]{
                        "Lendario",
                        "Prata"
                    }
                },
            };
        }
    }
}