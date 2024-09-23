using Autofac;
using FluentValidation;
using LibraryApp.Business.Concrete;
using LibraryApp.Business.Contracts;
using LibraryApp.Business.Validation.FluentValidation;
using LibraryApp.DataAccess.Concrete.InMemory;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;

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

            // Validation configures

            // Author validation configure
            builder.RegisterType<FvAuthorValidator>().As<IValidator<Author>>();

            // Book validation configure
            builder.RegisterType<FvBookValidator>().As<IValidator<Book>>();
        }
    }
}
