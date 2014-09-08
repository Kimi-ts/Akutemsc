using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace AkuteSinglePage
{
    public class Bootstraper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //GlobalConfiguration.Configuration.DependencyResolver = (IDependencyResolver)new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //container.RegisterType<IUserRepository, MongoDAL.UserRepository>();
            //container.RegisterType<ITokenRepository, MongoDAL.TokenRepository>();
            //container.RegisterType<IMessageRepository, MongoDAL.MessageRepository>();
            container.RegisterInstance("AkuteDBEntities", new AkuteSinglePage.Models.AkuteDBEntities());

            return container;
        }
    }
}