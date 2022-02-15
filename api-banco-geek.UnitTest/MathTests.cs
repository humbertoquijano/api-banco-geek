using System;
using Xunit;
using Xunit.Abstractions;

namespace api_banco_geek.UnitTest
{
    public class MathTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MathTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Must_Produce_Valid_Fibonacci_Values()
        {
            decimal fibonacci_40 = 63245986;
            decimal fibonacci_70 = 117669030460994;
            decimal fibonacci_100 = 218922995834555169026M;

            decimal testval_40 = 0;
            decimal testval_70 = 0;
            decimal testval_100 = 0;

            decimal a = 0;
            decimal b = 1;
            decimal fibonacciValue;

            for (int i = 3; i < 101; i++)
            {
                fibonacciValue = a + b;
                a = b;
                b = fibonacciValue;

                if (i == 40) { testval_40 = fibonacciValue; }
                if (i == 70) { testval_70 = fibonacciValue; }
                if (i == 100) { testval_100 = fibonacciValue; }
            }

            Assert.Equal(fibonacci_40, testval_40);
            Assert.Equal(fibonacci_70, testval_70);
            Assert.Equal(fibonacci_100, testval_100);

            _testOutputHelper.WriteLine($"fibonnacio 40:{testval_40}");
            _testOutputHelper.WriteLine($"fibonnacio 70:{testval_70}");
            _testOutputHelper.WriteLine($"fibonnacio 100:{testval_100}");
        }

        [Fact]
        public void Decimal_Must_Host_2Max_Integers()
        {
            int a = int.MaxValue;
            int b = int.MinValue;
            decimal testDecimal = decimal.MaxValue;

            Assert.True(testDecimal >= (a + b));
        }
    }
}
