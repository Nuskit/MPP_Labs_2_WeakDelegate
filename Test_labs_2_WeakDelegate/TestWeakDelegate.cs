using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_labs_2_WeakDelegate
{
  [TestClass]
  public class TestWeakDelegate
  {
    private WeakDelegateTestClass TestWeakClass
    {
      get
      {
        return new WeakDelegateTestClass();
      }
    }

    [TestMethod]
    public void TestTwoParam()
    {

      var weakReference=new WeakReference(TestWeakClass.Sum);
      weakReference.Weak.Invoke(5,6);
      Assert.AreEqual(WeakDelegateTestClass.IntValue, 11);
    }
  }
}
