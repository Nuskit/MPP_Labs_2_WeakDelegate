using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labs_2_WeakDelegate;

namespace Test_labs_2_WeakDelegate
{
  [TestClass]
  public class TestWeakDelegateDefault
  {
    private WeakDelegateTestClass TestWeakClass
    {
      get
      {
        return new WeakDelegateTestClass();
      }
    }

    [TestMethod]
    public void TestDefaultTwoParam()
    {
      var testWeakClass = TestWeakClass;
      Delegate weakReference = new WeakDelegateDefault((Action<int, int>)testWeakClass.Sum);

      weakReference.DynamicInvoke(5, 6);
      Assert.AreEqual(testWeakClass.IntValue, 11);
    }

    [TestMethod]
    public void TestDefaultNullFunc()
    {
      var testWeakClass = TestWeakClass;
      Delegate weakReference = new WeakDelegateDefault((Action)testWeakClass.NullFunc);
      weakReference.DynamicInvoke();
      Assert.AreEqual(testWeakClass.IntValue,1);
    }

    [TestMethod]
    public void TestDefaultThreeParam()
    {
      var testWeakClass = TestWeakClass;
      Delegate weakReference = new WeakDelegateDefault((Action<int,string,byte>)testWeakClass.ThreeParam);
      weakReference.DynamicInvoke(5,"6",(byte)1);
      Assert.AreEqual(testWeakClass.IntValue, 12);
    }

    private event Action SampleEvent;

    [TestMethod]
    public void TestDefaultWeakLink()
    {
      WeakDelegateDefault weakDelegate= new WeakDelegateDefault((Action)TestWeakClass.NullFunc);
      SampleEvent += (Action)weakDelegate;
      SampleEvent.DynamicInvoke();
      Assert.IsFalse(weakDelegate.IsNullTarget);
      GC.Collect();
      SampleEvent.DynamicInvoke();
      Assert.IsTrue(weakDelegate.IsNullTarget);
    }

    private event Func<int> FuncEvent;
    [TestMethod]
    public void TestDefaultWeakDelete()
    {
      FuncEvent += (Func<int>)new WeakDelegateDefault((Func<int>)TestWeakClass.TestWeakDelete);

      Assert.AreEqual(FuncEvent.DynamicInvoke(),5);
      GC.Collect();
      Assert.AreEqual(FuncEvent.DynamicInvoke(),0);
    }

    [TestMethod]
    public void TestDefaultReturnValue()
    {
      var testWeakClass = TestWeakClass;
      Delegate weakReference = new WeakDelegateDefault((Func<int,int,int,int>)testWeakClass.Generic);
      Assert.AreEqual((int)weakReference.DynamicInvoke(3, 4, 5), 12);
    }
  }
}
