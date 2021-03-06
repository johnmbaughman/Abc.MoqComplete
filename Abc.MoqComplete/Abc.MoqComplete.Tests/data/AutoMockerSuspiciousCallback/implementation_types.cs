using Moq;
using Moq.AutoMock;

namespace ConsoleApp1.Tests
{
    public interface ITest
    {
        void Do(ITest test, ITest2 test2, string test3);
    }
    
    public interface ITest2
    {
		void Temp();
    }

    class Test2 : ITest2
    {
		public void Temp()
		{
		}
    }

    public class TestClass
    {
        public void METHOD()
        {
            var test2 = new Test2();
            var _mocker = new AutoMocker();
            _mocker.Setup<ITest>(x => x.Do(It.IsAny<ITest>(), test2, It.IsAny<string>())).Callback<ITest, ITest2, string>((test, ptest2, test3 ) => ptest2.Temp());
        }
    }
}