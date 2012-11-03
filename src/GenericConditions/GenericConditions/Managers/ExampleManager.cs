using GenericConditions.Common;
using GenericConditions.Requests;
using GenericConditions.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConditions.Managers
{
    public class ExampleManager
    {
        public ExampleResponse ValidateExampleWithoutGenerics(ExampleRequest request)
        {
            ExampleResponse response = new ExampleResponse();

            Condition1(request, ref response);
            Condition2(request, ref response);
            Condition3(request, ref response);
            //could be many conditions...
            DoWork(request, ref response);

            return response;
        }

        public ExampleResponse ValidateExampleWithGenerics(ExampleRequest request)
        {
            ExampleResponse response = new ExampleResponse();

            List<Action<ExampleResponse>> todo = new List<Action<ExampleResponse>>() 
            { 
                {(r) => {Condition4(request, ref r);} },
                {(r) => {Condition5(request, ref r);} },
                {(r) => {Condition6(request, ref r);} },
                {(r) => {DoWork2(request, ref r);} },
            };

            //DoToDo<ExampleResponse>(todo, ref response);
            todo.RunWithShortCircuit(ref response);

            return response;
        }

        //Uses generic IResponse so this method could work accross all calls that inherit from IResponse
        private void DoToDo<T>(List<Action<T>> actions, ref T response)
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

        private void Condition1(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition1Ran = true;

            if (response.Status.StatusCode == 0)
            {
                if (request.SomeVariable != request.SomeOtherVariable)
                {
                    response.Status.StatusCode = 1;
                    response.Status.StatusDescription = "Error";
                } 
                //additional validation may be here...
            }
        }

        private void Condition2(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition2Ran = true;

            if (response.Status.StatusCode == 0)
	        {
                if (request.SomeOtherOtherVariable == "error")
                {
                    response.Status.StatusCode = 1;
                    response.Status.StatusDescription = "Error";
                }
                //additional validation may be here...
	        }
        }

        private void Condition3(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition3Ran = true;

            if (response.Status.StatusCode == 0)
            {
                if (request.SomeOtherVariable == "abc")
                {
                    response.Status.StatusCode = 1;
                    response.Status.StatusDescription = "Error";
                }
                //additional validation may be here...
            }
        }

        private void DoWork(ExampleRequest request, ref ExampleResponse response)
        {
            response.DoWorkRan = true;

            if (response.Status.StatusCode == 0)
            {
                //do work here...
            }
        }

        private void Condition4(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition4Ran = true;

            if (request.SomeVariable != request.SomeOtherVariable)
            {
                response.Status.StatusCode = 1;
                response.Status.StatusDescription = "Error";
            }
            //additional validation may be here...
        }

        private void Condition5(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition5Ran = true;

            if (request.SomeOtherOtherVariable == "error")
            {
                response.Status.StatusCode = 1;
                response.Status.StatusDescription = "Error";
            }
            //additional validation may be here...
        }

        private void Condition6(ExampleRequest request, ref ExampleResponse response)
        {
            response.Condition6Ran = true;

            if (request.SomeOtherVariable == "abc")
            {
                response.Status.StatusCode = 1;
                response.Status.StatusDescription = "Error";
            }
            //additional validation may be here...
        }

        private void DoWork2(ExampleRequest request, ref ExampleResponse response)
        {
            response.DoWork2Ran = true;
            //do work here...
        }
    }
}
