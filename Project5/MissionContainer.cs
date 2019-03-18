// shahar leitner, 208524975, group 05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double unaryFunction(double input);
    public class FunctionsContainer
    {

        private Dictionary<string, unaryFunction> pairs;
        public FunctionsContainer()
        {
            pairs = new Dictionary<string, unaryFunction>();
        }
        public unaryFunction this[string key]
        {
            get
            {
                pairs.TryGetValue(key, out unaryFunction check);
                if (check == default(unaryFunction))
                {
                    pairs[key] = val => val;
                    return val => val;
                } else
                {
                    return check;
                }
            }
            set
            {
                pairs[key] = value;
            }
        }

        public List<string> getAllMissions()
        {
            return new List<string>(pairs.Keys);
        }
    }
}
