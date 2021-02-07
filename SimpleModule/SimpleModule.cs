using ConfigInterfacing.Shared;
using SimpleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleModule
{
    public class SimpleModule : IProcessHandler

    {
        private MyCustomConfig Config { get; set; }
        public SimpleModule(MyCustomConfig config)
        {
            Config = config;
        }
        public void Run()
        {
            Console.WriteLine(Config.Name);
            Console.WriteLine(Config.Element.Value);
            Console.WriteLine(Config.Element.FilePath);
        }
    }
}
