using System;
using System.Collections.Generic;
using System.Text;
using TestReflextionAttributes.Models;
using TestReflextionAttributes.SP;

namespace TestReflextionAttributes
{
    public class TestDataContext
    {
        public DBSet<TestModel> TestModel { get; set; }


    }
}
