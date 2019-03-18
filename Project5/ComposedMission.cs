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

        // a containter to hold all of the delegates we will activate
        private List<unaryFunction> functions;

        public ComposedMission(string n)
        {
            // create the composed mission based on the name.
            Name = n;
            Type = "Composed";
            functions = new List<unaryFunction>();
        }

        public String Name { get; }

        public String Type { get; }

        public ComposedMission Add(unaryFunction f)
        {
            // check if the input is initialized.
            if (f != default(unaryFunction))
            {
                // if it is add it to the list.
                functions.Add((unaryFunction) f.Clone());
                return this;
            } else
            {
                return this;
            }
        }

        public double Calculate(double value)
        {
            // calculate the return value by activating all of the function
            foreach (var func in functions)
            {
                value = func(value);
            }
            // invoke the event if it is initialized
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}
