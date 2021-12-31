using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yalikh.Utils.Reflection;

namespace Yalikh.Utils.Tests.Reflection
{
    public class AttributeHelperTests
    {
        [Fact]
        public void GettingClassAttrFromProperty()
        {
            var type = typeof(TestClass);
            var attrType = typeof(ClassMarkAttribute);

            var result = type.TryGetAttrValue<string>(attrType, "PropVal", out var value);

            Assert.True(result);
            Assert.Equal("propvalue", value);
        }

        [Fact]
        public void GettingClassAttrFromMethod()
        {
            var type = typeof(TestClass);
            var attrType = typeof(ClassMarkAttribute);

            var result = type.TryGetAttrValue<int>(attrType, "GetMethodVal", out var value);

            Assert.True(result);
            Assert.Equal(125, value);
        }
    }
}
