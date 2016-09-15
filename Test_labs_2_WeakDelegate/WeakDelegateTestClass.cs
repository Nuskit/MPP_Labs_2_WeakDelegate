using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_labs_2_WeakDelegate
{
  class WeakDelegateTestClass
  {
    public static int IntValue { get; set; }

    public static float FloatValue { get; set; }

    public void Sum(int left,int right)
    {
      IntValue= left + right;
    }

    public void Multi(int left,float right)
    {
      FloatValue = left * right;
    }

    public void Generic(int first,int second,int third)
    {
      IntValue = first + second + third;
    }
  }
}
