using System;

namespace TestDLL
{
    public class TestDLLClass
    {
        /// <summary>
        /// Attribute documentation
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// This function take an integer number, add 100 to it and then return it...
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Hi, this is the function return</returns>
        public int TestFunction(int num)
        {
            num += 100;
            return num;
        }
    }
}
