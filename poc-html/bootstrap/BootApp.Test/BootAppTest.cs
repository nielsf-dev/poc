using System.Threading;
using System.Threading.Tasks;
using BootApp.Code;
using NUnit.Framework;

namespace BootApp.Test
{
    public class BootAppTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPerson()
        {
            var person = new Person("nelus", 39);
            Assert.AreEqual("nelus", person.Name);
        }

        [Test]
        public async Task TestFileReader()
        {
            var reader = new AsyncFileReader(@"D:\work\SchoneData_filtered.xml");

            var cts = new CancellationTokenSource();
            string content = await reader.Read(cts.Token).ConfigureAwait(false);

            cts.Cancel();
            Assert.IsNotEmpty(content);
        }


    }
}