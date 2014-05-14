using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using awsmSeeSharpGame;
using System.Threading;
using Moq;

namespace awsmSeeSharpGameUnitTest
{
    [TestClass]
    public class GameTimerTest
    {
        private Mock<ITimer> timer;
        private GameTimer gameTimer;
        private TimeSpan ettTick;

        [TestInitialize]
        public void SetupForTest()
        {
            timer = new Mock<ITimer>();
            ettTick = new TimeSpan(0,0,0);
        }
        
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
        

        [TestMethod]
        public void ShouldStopDisplayingWarningsWhenTimeIsOut()
        {
            timer = new Mock<ITimer>();
            timer.Object.Interval = 1;
            gameTimer = new GameTimer(timer.Object, ettTick);
            //gameTimer timer.Raise(e => e.Elapsed, EventArgs.Empty);
            Assert.IsFalse(gameTimer.IsRunning());

            


          
        }

    }
}
