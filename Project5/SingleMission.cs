// shahar leitner, 208524975, group 05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated
        private unaryFunction function;
        public SingleMission(unaryFunction f, string name)
        {
            function = f;
            Name = name;
            Type = "Single";
        }
        public String Name { get; }
        public String Type { get; }

        public double Calculate(double value)
        {
            OnCalculate?.Invoke(this, function(value));
            return function(value);
        }
    }
}
