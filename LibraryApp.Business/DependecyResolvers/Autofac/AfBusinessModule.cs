using Autofac;
using LibraryApp.Business.Concrete;
using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Concrete.InMemory;
using LibraryApp.DataAccess.Contracts;

namespace LibraryApp.Business.DependecyResolvers.Autofac
{
    public class AfBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // User dependency configure
            builder.RegisterType<InMemoryUserDao>().As<IUserDao>();
            builder.RegisterType<UserManager>().As<IUserService>();

            // Book dependency configure
            builder.RegisterType<InMemoryBookDao>().As<IBookDao>();
            builder.RegisterType<BookManager>().As<IBookService>();

            // Author dependency configure
            builder.RegisterType<InMemoryAuthorDao>().As<IAuthorDao>();
            builder.RegisterType<AuthorManager>().As<IAuthorService>();

            // Service dependency configure
            builder.RegisterType<ServiceManager>().As<IServiceManager>();
        }
    }
}
