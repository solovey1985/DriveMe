using System;
using Autofac;

namespace TestByConsole
{
    class Program
    {
        static IContainer container;
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Repository>().As<IRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            container = builder.Build();
            DoSomeWork();
            Console.ReadLine();
        }

        public static void DoSomeWork()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                IRepository repo = container.Resolve<IRepository>();
                repo.GetSimpleString();
            }
        }
    }

    public interface IRepository
    {
        void GetSimpleString();
    }

    public class Repository : IRepository
    {
        IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void GetSimpleString()
        {
            Console.WriteLine($"Execution of interface at {_unitOfWork.GetCurrentDate() }");
        }
    }

    public interface IUnitOfWork
    {
        string GetCurrentDate();
    }

    public class UnitOfWork:IUnitOfWork
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToString("F");
        }
    }
}
