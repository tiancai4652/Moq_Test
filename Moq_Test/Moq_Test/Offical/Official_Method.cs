using Moq;
using Moq_Test.Offical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Moq_Test
{
    /// <summary>
    /// 官方
    /// https://github.com/Moq/moq4/wiki/Quickstart 
    /// </summary>
    public class Official_Method
    {
        Mock<IFoo> mock = new Mock<IFoo>();

        #region Method

        /// <summary>
        /// 特定输入才能返回特定输出
        /// </summary>
        [Trait("Method", "Setup:IO")]
        [Fact]
        public void Test_Setup_InputOutput_True()
        {
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            Assert.True(mock.Object.DoSomething("ping"));
        }

        [Trait("Method", "Setup:IO")]
        [Fact]
        public void Test_Setup_InputAndOutput_False()
        {
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            Assert.False(mock.Object.DoSomething("xxx"));
        }

        /// <summary>
        /// 特定输入才能返回特定输出,Out
        /// </summary>
        [Trait("Method", "Setup:IO Out")]
        [Fact]
        public void Test_Setup_InputAndOutputOut_True()
        {
            string temp = "";
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            Assert.True(mock.Object.TryParse("ping", out temp));
            Assert.Equal(outString, temp);
        }

        [Trait("Method", "Setup:IO Out")]
        [Fact]
        public void Test_Setup_InputAndOutputOut_ResultFalse()
        {
            string temp = "";
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            Assert.False(mock.Object.TryParse("xxx", out temp));
        }

        [Trait("Method", "Setup:IO Out")]
        [Fact]
        public void Test_Setup_InputAndOutputOut_OutFalse()
        {
            string temp = "";
            var outString = "ack";
            // TryParse will return true, and the out argument will return "ack", lazy evaluated
            mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);
            Assert.NotEqual(outString + "1", temp);
        }

        /// <summary>
        /// 特定Ref才能产生特定输出
        /// </summary>
        [Trait("Method", "Setup:O Ref")]
        [Fact]
        public void Test_Setup_InputAndOutputRef_True()
        {
            // ref arguments
            var instance = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            Assert.True(mock.Object.Submit(ref instance));
        }

        [Trait("Method", "Setup:O Ref")]
        [Fact]
        public void Test_Setup_InputAndOutputRef_ResultFalse()
        {
            // ref arguments
            var instance = new Bar();
            var instanceSecond = new Bar();
            // Only matches if the ref argument to the invocation is the same instance
            mock.Setup(foo => foo.Submit(ref instance)).Returns(true);
            Assert.False(mock.Object.Submit(ref instanceSecond));
        }

        /// <summary>
        /// 当Any String==Null时，会报错
        /// </summary>
        /// <param name="st"></param>
        [Trait("Method", "Setup:Any I --> Special O")]
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("")]
        public void Test_AnyIToSpecialO_True(string st)
        {
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
        .Returns((string s) => s.ToLower());
            Assert.Equal(st.ToLower(), mock.Object.DoSomethingStringy(st));
        }

        [Trait("Method", "Setup:Any I --> Special O")]
        [Theory]
        [InlineData(null)]
        public void Test_AnyIToSpecialO_False(string st)
        {
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
        .Returns((string s) => s.ToLower());
            Assert.Throws<NullReferenceException>(() => mock.Object.DoSomethingStringy(st));
        }

        [Trait("Method", "Setup:Throw Exception")]
        [Fact]
        public void Test_ThrowException_True()
        {
            mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));
            Assert.Throws<InvalidOperationException>(()=> mock.Object.DoSomething("reset"));
            Assert.Throws<ArgumentException>(() => mock.Object.DoSomething(""));
        }

        #endregion


    }
}
