using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using awsmSeeSharpGame;
using System.Threading;

namespace awsmSeeSharpGameUnitTest.Classes
{
    [TestClass]
    public class GameTimerTest
    {
        [TestMethod]
        public void TestSjekkAtTimerenTellerNed()
        {
            TimeSpan startTid = new TimeSpan(0, 0, 5);
            TimeSpan expected = new TimeSpan(0, 0, 4);
            GameTimer timer = new GameTimer(startTid);
            Thread.Sleep(1100);
            Assert.AreEqual(expected, timer.GetTid());
        }
        [TestMethod]
        public void TestSjekkAtTimerenStopper()
        {
            TimeSpan startTid = new TimeSpan(0);
            Boolean expected = false;
            GameTimer timer = new GameTimer(startTid);
            Thread.Sleep(1100);
            Assert.AreEqual(expected, timer.IsRunning());
        }
    }
}
