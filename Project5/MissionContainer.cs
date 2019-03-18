// shahar leitner, 208524975, group 05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    // the delegate for math functions.
    public delegate double unaryFunction(double input);

    public class FunctionsContainer
    {
        // will hold pair of string and delegate.
        private Dictionary<string, unaryFunction> pairs;

        public FunctionsContainer()
        {
            // initialize.
            pairs = new Dictionary<string, unaryFunction>();
        }

        public unaryFunction this[string key]
        {
            get
            {
                // check if the name is in our dictionary
                pairs.TryGetValue(key, out unaryFunction check);
                // the name isn't in the dictionary
                if (check == default(unaryFunction))
                {
                    // add it as a function that returns nothing.
                    pairs[key] = val => val;
                    // return a function that does nothing.
                    return val => val;
                } else
                {
                    // return the delegate of the key.
                    return check;
                }
            }
            set
            {
                // put the function into the list.
                pairs[key] = value;
            }
        }

        public List<string> getAllMissions()
        {
            // get all of the keys and put them into a list.
            return new List<string>(pairs.Keys);
        }
    }
}
