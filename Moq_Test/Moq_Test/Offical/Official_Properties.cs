using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Moq_Test.Offical
{
   public class Official_Properties
    {
        Mock<IFoo> mock = new Mock<IFoo>();

        [Trait("Property", "Setup:Property")]
        [Fact]
        public void Test_SetProperty_True()
        {
            mock.Setup(foo => foo.Name).Returns("bar");
            Assert.Equal("bar", mock.Object.Name);
        }

        [Trait("Property", "Setup:ChlidProperty")]
        [Fact]
        public void Test_SetChlidProperty_True()
        {
            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(foo => foo.Bar.Baz.Name).Returns("baz");
            Assert.Equal("baz", mock.Object.Bar.Baz.Name);
        }


        [Trait("Property", "SetupSet:ChlidProperty")]
        [Fact(Skip ="没弄懂这个东西什么时候使用")]
        public void Test_SetupSetProperty_True()
        {
            // expects an invocation to set the value to "foo"
            mock.SetupSet(foo => foo.Name = "foo");
            Assert.Equal("foo", mock.Object.Name);

        }

        [Trait("Property", "VerifySet:ChlidProperty")]
        [Fact(Skip = "没弄懂这个东西什么时候使用")]
        public void Test_VerifySetProperty_True()
        {
            // or verify the setter directly
            mock.VerifySet(foo => foo.Name = "foo");
            Assert.Equal("foo", mock.Object.Name);
        }
    }
}
