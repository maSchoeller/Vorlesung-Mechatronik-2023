using System.Linq;

using Xunit;

namespace Aufgabe_Linq
{
    public class LinqTasks
    {
        [Fact]
        public void Task1()
        {
            var result = FilterPersons.Task1(HeroDummyData.GetPersons());

            Assert.All(result, p => Assert.NotNull(p.Assistant));
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Task2()
        {
            var result = FilterPersons.Task2(HeroDummyData.GetPersons());

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void Task3()
        {
            var result = FilterPersons.Task3(HeroDummyData.GetPersons());

            Assert.Equal("Batman", result.HeroName);
            Assert.Equal(HeroType.Technology, result.Type);
        }

        [Fact]
        public void Task4()
        {
            var result = FilterPersons.Task4(HeroDummyData.GetPersons());

            Assert.NotNull(result.Assistant);
            Assert.True(result.Assistant is not Hero);
        }

        [Fact]
        public void Task5()
        {
            var result = FilterPersons.Task5(HeroDummyData.GetPersons());

            Assert.Equal(3, result);
        }

        [Fact]
        public void Task6()
        {
            var result = FilterPersons.Task6(HeroDummyData.GetPersons());
            Assert.Equal(1_071_500, result);
        }

        [Fact]
        public void Task7()
        {
            var result = FilterPersons.Task7(HeroDummyData.GetPersons());
            Assert.Equal(78_750, result);
        }

        [Fact]
        public void Task8()
        {
            var result = FilterPersons.Task8(HeroDummyData.GetPersons());


            Assert.Single(result);
            Assert.Equal("Superman", result.First().Name);
        }

    }
}
