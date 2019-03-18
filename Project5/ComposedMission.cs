// shahar leitner, 208524975, group 05
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated
        private List<unaryFunction> functions;
        public ComposedMission(string n)
        {
            Name = n;
            Type = "Composed";
            functions = new List<unaryFunction>();
        }
        public String Name { get; }
        public String Type { get; }
        public ComposedMission Add(unaryFunction f)
        {
            if (f != default(unaryFunction))
            {
                functions.Add(f);
                return this;
            } else
            {
                return this;
            }
        }
        public double Calculate(double value)
        {
            foreach (var func in functions)
            {
                value = func(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
