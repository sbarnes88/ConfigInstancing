using Autofac;
using ConfigInterfacing.Shared;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConfigInterfacing
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new App(args[0]);
            a.Run();
            Console.ReadKey();
        }
    }

    public class App
    {
        private IContainer Container { get; set; }

        public App(string file)
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var builder = new ContainerBuilder();
            var actualBuilder = new ContainerBuilder();
            var customAsm = new[] { Assembly.LoadFile(Path.Combine(workingDirectory,"SimpleModule.dll")) };
            var asm = new[] { Assembly.GetAssembly(typeof(Program)) };
            builder.RegisterTypes(typeof(IBaseConfig)).AsSelf();
            builder.RegisterAssemblyTypes(customAsm).AsImplementedInterfaces();
            var custom = builder.Build();
            var configType = custom.Resolve<IBaseConfig>();
            actualBuilder.Register(c =>
                Config.Initialize(file, configType.GetType()))
                .As(configType.GetType()).SingleInstance();
            actualBuilder.RegisterAssemblyTypes(asm.Union(customAsm).ToArray())
                .AsImplementedInterfaces();
            Container = actualBuilder.Build();
        }
        public void Run()
        {
            Container.Resolve<IProcessHandler>().Run();
        }
    }
    //public interface IProcess
    //{
    //    void Run();
    //}
    //public class Process : IProcess
    //{
    //    private PConfig Config { get; set; }
    //    public Process(PConfig config)
    //    { 
    //        Config = config; 
    //    }
    //    public void Run()
    //    {

    //    }
    //}

    //[DataContract]
    //public class PConfig : IBaseConfig
    //{
    //    [DataMember]
    //    public string Name { get; set; }
    //    [DataMember]
    //    public Options Options { get; set; }
    //}

    //[DataContract]
    //public class Options
    //{
    //    [DataMember]
    //    public string Alpha { get; set; }
    //}
}
