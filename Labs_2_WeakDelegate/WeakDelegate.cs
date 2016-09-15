using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_2_WeakDelegate
{
  public class WeakDelegate
  {
    private WeakReference weakReference;
    public WeakDelegate(Type action)
    {
      if (action as Delegate);
      weakReference = new WeakReference(action);
    }

    public Type Weak { get; set; }
  }
}
