using GenericConditions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConditions
{
    public static class ExtensionMethods
    {
        //An extension method to do the same thing as DoToDo
        public static void RunWithShortCircuit<T>(this List<Action<T>> actions, ref T response)
            where T : IResponse
        {
            foreach (var action in actions)
            {
                if (response.Status.StatusCode == 0)
                {
                    action.Invoke(response);
                }
                else
                {
                    // short circuits the rest of the actions from running
                    break;
                }
            }
        }
    }
}
