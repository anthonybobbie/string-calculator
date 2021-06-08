using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
 using StringCalculatorAssignment.Models;

namespace StringCalculatorAssignment
{
    public class Container : NinjectModule
    {
        public override void Load()
        {
            
            this.Bind<DelimeterService>().To<DelimeterService>();
            this.Bind<StringCalculator>().To<StringCalculator>();


        }
    }
}
