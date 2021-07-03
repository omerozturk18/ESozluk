using Autofac;
using BusinessLibrary.Abstract;
using BusinessLibrary.Concrete;

using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<ContentManager>().As<IContentService>().SingleInstance();
            builder.RegisterType<EfContentDal>().As<IContentDal>().SingleInstance();

            builder.RegisterType<HeadingManager>().As<IHeadingService>();
            builder.RegisterType<EfHeadingDal>().As<IHeadingDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<SkillManager>().As<ISkillService>();
            builder.RegisterType<EfSkillDal>().As<ISkillDal>();

            builder.RegisterType<WriterManager>().As<IWriterService>();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>();

            builder.RegisterType<StatisticManager>().As<IStatisticService>();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
