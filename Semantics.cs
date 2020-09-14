using System;
using System.Linq;
namespace ProseTutorial
{
    public static class Semantics
    {
        public static int Substring(int[] v, int start, int end)
        {
            return start + end;
        }

        public static int? AbsPos(int[] v, int k)
        {
            return k - 1;
        }
    }
}