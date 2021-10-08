using Bug_Management_App.Controllers;
using Bug_Management_App.Repos;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Bug_Management_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IRegisterUsers, SqlUsersRepo>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}