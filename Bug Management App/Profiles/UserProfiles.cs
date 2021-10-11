using AutoMapper;
using Bug_Management_App.Dtos;
using Bug_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<RegisterUserDto, Users>();
            CreateMap<Users, RegisterUserDto>();
        }
        
    }
}