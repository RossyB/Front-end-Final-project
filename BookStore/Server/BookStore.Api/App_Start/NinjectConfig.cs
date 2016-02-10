namespace BookStore.Api
{
    using System;
    using System.Web;
    using BookStore.Data;
    using BookStore.Data.Repositories;
    using BookStore.Services;
    using BookStore.Services.Contracts;
    using Ninject;
    using Ninject.Web.Common;


    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBookStoreDbContext>().To<BookStoreDbContext>();
            kernel.Bind(typeof (IRepository<>)).To(typeof (GenericRepository<>));

            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IBookService>().To<BookService>();
        }
    }
}