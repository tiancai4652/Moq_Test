using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Moq_Test.Offical
{
    public class Official_MatchingArguments
    {

        //Get:
        //string x = null;
        //string m = x.ToString();
        //输入：It.Ref<Bar>.IsAny
        //如果Mock里面有针对x操作方法，会报空引用异常
        //否则会返回False
        //请看Test_Setup_MacthArgu1()和Official_Method.Test_AnyIToSpecialO_False()



        Mock<IFoo> mock = new Mock<IFoo>();

        [Trait("Method", "Setup:Match Argu")]
        [Fact]
        public void Test_Setup_MacthArgu1()
        {
            // any value
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);
            Assert.True(mock.Object.DoSomething(""));
            Assert.True(mock.Object.DoSomething("11"));
            //Assert.Throws<NullReferenceException>(() => mock.Object.DoSomething(null));
            Assert.True(mock.Object.DoSomething(null));

            // matching regex
            //mock.Setup(x => x.DoSomethingStringy(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");
        }

        [Trait("Method", "Setup:Match Argu")]
        [Fact]
        public void Test_Setup_MacthArgu2()
        {
            // any value passed in a `ref` parameter (requires Moq 4.8 or later):
            mock.Setup(foo => foo.Submit(ref It.Ref<Bar>.IsAny)).Returns(true);
            var barInistance = new Bar();
            var otherInsitance = new Baz();
            Assert.True(mock.Object.Submit(ref barInistance));
            //Assert.False(mock.Object.Submit(ref otherInsitance));
        }

        [Trait("Method", "Setup:Match Argu")]
        [Fact]
        public void Test_Setup_MacthArgu3()
        {
            // matching Func<int>, lazy evaluated
            mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);
            Assert.True(mock.Object.Add(0));
            Assert.False(mock.Object.Add(1));

        }

        [Trait("Method", "Setup:Match Argu")]
        [Fact]
        public void Test_Setup_MacthArgu4()
        {
            // matching ranges
            mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);
            Assert.True(mock.Object.Add(0));
            Assert.True(mock.Object.Add(5));
            Assert.True(mock.Object.Add(10));
            Assert.False(mock.Object.Add(11));
        }
    }
}
