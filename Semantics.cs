using System;
using System.Linq;
namespace ProseTutorial
{
    public static class Semantics
    {
        public static int Add(int[] v, int start, int end)
        {
            return start + end;
        }
        public static int multiply(int[] v, int start, int end)
        {
            return start*end;
        }
        public static int divide(int[] v, int start, int end)
        {
            return end!=0?start/end:0;
        }

        public static int? AbsPos(int[] v, int k)
        {
            return k - 1;
        }
    }
}
