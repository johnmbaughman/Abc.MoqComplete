// ${COMPLETE_ITEM:Returns<int,string,bool>((i,toto,ok) => )}
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public interface ITestInterface
    {
        int BuildSomething(int i, string toto, bool ok);
    }

    [TestFixture]
    public class Test1
    {
        [Test]
        public void METHOD()
        {
            var _mocker = new AutoMocker();
            _mocker.Setup<ITestInterface>(x => x.BuildSomething(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Callback<int,string,bool>((i,toto,ok) => {})
                .R{caret}
        }
    }
}