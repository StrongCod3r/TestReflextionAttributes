using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestReflextionAttributes.Models;
using TestReflextionAttributes.SP;

namespace TestReflextionAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<TestModel>();

            for (int i = 0; i < 10; i++)
            {
                var newItem = new TestModel
                {
                    Id = i,
                    Name = "nombre" + i,
                    SurName = "surname" + i,
                };
                if (i % 2 == 0)
                {
                    newItem.BirthDate = DateTime.Now;
                    newItem.IsActive = true;
                }
                testData.Add(newItem);
            }

            foreach (var item in testData)
            {
                item.SetPropValue("Name", "Prueba");
            }

            DataContext.Process(testData);
            Console.ReadKey();
        }
    }
}
