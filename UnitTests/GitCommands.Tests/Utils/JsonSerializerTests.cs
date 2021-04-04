using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitCommands.Utils;
using NUnit.Framework;

namespace GitCommandsTests.Utils
{
    [TestFixture]
    public class JsonSerializerTests
    {
        private List<int> _validObject;
        private string _validObjectSerialized;

        [OneTimeSetUp]
        public void Setup()
        {
            _validObject = new List<int> { 1, 2, 3, 4 };
            _validObjectSerialized = "[1,2,3,4]";
        }

        [Test]
        public void Valid_object_serialized_should_equal_provided_serialized_version()
        {
            var serialized = JsonSerializer.Serialize(_validObject);

            Assert.AreEqual(_validObjectSerialized, serialized);
        }

        [Test]
        public void Valid_object_deserialized_should_equal_provided_deserialized_version()
        {
            var deserialized = JsonSerializer.Deserialize<List<int>>(_validObjectSerialized);

            Assert.AreEqual(_validObject, deserialized);
        }

    }
}
