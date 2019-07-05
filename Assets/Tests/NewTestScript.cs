using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using QQQ.Core;
using System.IO;
using System;

namespace Tests
{
    public class NewTestScript
    {
        [Test]
        public void JsonSerializeTest()
        {
            var testClassB = new TestClassB()
            {
                intvalue = 5,
                stringvalue = "testclassB",
            };

            var testClassA = new TestClassA()
            {
                intvalue = 3,
                stringvalue = "testclassA",
                classB = testClassB,
            };

            var serializedJson = JsonUtility.ToJson(testClassA);
            var test = JsonUtility.FromJson<TestClassA>(serializedJson);

            Assert.AreEqual(test.stringvalue, "testclassA");
            Assert.AreEqual(test.classB.stringvalue, "testclassB");
        }

        [Test]
        public void JsonPersistentSaveTest()
        {
            var testClassB = new TestClassB()
            {
                intvalue = 5,
                stringvalue = "testclassB",
            };

            var testClassA = new TestClassA()
            {
                intvalue = 3,
                stringvalue = "testclassA",
                classB = testClassB,
            };

            string line = "";

            PersistentData.SaveToJson(testClassA);
            var a = PersistentData.LoadFromJson<TestClassA>();
            var test = JsonUtility.FromJson<TestClassA>(line);
            Assert.AreEqual(a.classB.stringvalue, "testclassB");
            PersistentData.Delete<TestClassA>();
        }

        [Serializable]
        public class TestClassA
        {
            public int intvalue;
            public string stringvalue;
            public TestClassB classB;
        }

        [Serializable]
        public class TestClassB
        {
            public int intvalue;
            public string stringvalue;
        }
    }
}
