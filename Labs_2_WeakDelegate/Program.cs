using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_2_WeakDelegate
{
  class Program
  {
    
    private delegate void dof(int s);

    private static void dos(int b,int s)
    {
      ;
    }

    private static bool dok(int f,double r)
    {
      return true;
    }

    static void Main(string[] args)
    {
      var f=new Func<int, double,bool>(dok);
      WeakReference k = new WeakReference(f);
    }
  }
}
