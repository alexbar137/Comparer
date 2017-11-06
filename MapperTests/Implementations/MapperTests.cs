using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mapper.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;
using Parsers.Implemenations;
using Comparer.Interfaces;

namespace Mapper.Implementations.Tests
{
        
    [TestClass()]
    public class MapperTests
    {

        public List<ITUnit> original;
        public List<ITUnit> edited;


        [TestInitialize()]
        public void Startup()
        {
            original = new List<ITUnit>()
            {
                new TUnit() { Id = "1", Source = "Source1", Target = "Одинаково"},
                new TUnit() { Id = "2", Source = "Source2", Target = "Еще один сегмент"},
                new TUnit() { Id = "3", Source = "Source3", Target = "Третий сегмент"},
                new TUnit() { Id = "4", Source = "Source4", Target = "Нет такого сегмента"}
            };

            edited = new List<ITUnit>()
            {
                new TUnit() { Id = "1", Source = "Source1", Target = "Одинаково"},
                new TUnit() { Id = "2", Source = "Source2", Target = "Отредактированный сегмент"},
                new TUnit() { Id = "3", Source = "Source3", Target = ""},
                new TUnit() { Id = "5", Source = "Source5", Target = "Новый сегмент"}
            };

        }
        [TestMethod()]
        public void MapTest_Map_Count4()
        {
            Mapper mapper = new Mapper();
            List<ISegment> result = mapper.Map(original, edited);
            Assert.AreEqual(4, result.Count);
        }
    }
}