using System;
using System.Collections.Generic;
using System.Text;

namespace MindPalace.UnitTest.Core.Helper
{
    public static class TestHelper
    {
            public static bool AlmostEqualTo(this double value1, double value2)
            {
                return Math.Abs(value1 - value2) < 0.000001;
            }
    }
}
