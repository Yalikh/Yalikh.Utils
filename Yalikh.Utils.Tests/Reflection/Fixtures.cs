using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Yalikh.Utils.Tests.Reflection
{
    sealed class ClassMarkAttribute : Attribute
    {
        readonly string propVal;

        readonly int methodVal;

        public ClassMarkAttribute(string propVal, int methodVal)
        {
            this.propVal = propVal;
            this.methodVal = methodVal;
        }

        public string PropVal
        {
            get { return propVal; }
        }

        public int GetMethodVal()
        {
            return methodVal;
        }
    }

    [ClassMark("propvalue", 125)]
    class TestClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
