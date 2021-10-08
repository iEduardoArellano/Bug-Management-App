using AutoMapper;
using Bug_Management_App.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug_Management_App.Data
{
    public static class AutoMap
    {
        public static IMapper _mapper;

        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(
                config =>
                {
                    config.AddProfile<UserProfiles>();
                });

            _mapper = mapperConfiguration.CreateMapper();
        }
    }
}