using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericConditions.Managers;
using GenericConditions.Requests;
using GenericConditions.Responses;

namespace GenericConditions.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ValidateExampleWithoutGenerics_FailCondition1_Condition2Condition3DoWork_StillRun()
        {
            ExampleManager manager = new ExampleManager();
            ExampleRequest request = new ExampleRequest() { SomeVariable = "A", SomeOtherVariable = "B", SomeOtherOtherVariable = "C" };

            ExampleResponse response = manager.ValidateExampleWithoutGenerics(request);

            Assert.IsTrue(response.Condition1Ran);
            Assert.IsTrue(response.Condition2Ran);
            Assert.IsTrue(response.Condition3Ran);
            Assert.IsTrue(response.DoWorkRan);
        }

        [TestMethod]
        public void ValidateExampleWithGenerics_FailCondition3_Condition4Condition5DoWork2_DoNotRun()
        {
            ExampleManager manager = new ExampleManager();
            ExampleRequest request = new ExampleRequest() { SomeVariable = "A", SomeOtherVariable = "B", SomeOtherOtherVariable = "C" };

            ExampleResponse response = manager.ValidateExampleWithGenerics(request);

            Assert.IsTrue(response.Condition4Ran);
            Assert.IsFalse(response.Condition5Ran);
            Assert.IsFalse(response.Condition6Ran);
            Assert.IsFalse(response.DoWork2Ran);
        }
    }
}
