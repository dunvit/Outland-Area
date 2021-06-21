using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Outland_Area_CoreTests;

namespace Engine.Tools.Tests
{
    [TestClass()]
    public class OuterSpaceTests
    {
        [TestMethod()]
        public void MouseClickOnObjectAndChangeSelectedObject_Test()
        {
            var receivedEvents = new List<int>();

            var server = EnvironmentGlobal.CreateGameServer("OuterSpace");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var outerSpace = new OuterSpace();

            var isChangeSelectedObject = false;

            outerSpace.OnChangeSelectedObject += (e) =>
            {
                Assert.AreEqual(e, 5006);
                isChangeSelectedObject = true;
            };

            outerSpace.Refresh(gameSession, new System.Drawing.PointF(10101, 10201), MouseArguments.LeftClick);

            Assert.IsTrue(isChangeSelectedObject);

        }

        [TestMethod()]
        public void MouseClickOnObjectAndChangeActiveObject_Test()
        {
            var receivedEvents = new List<int>();

            var server = EnvironmentGlobal.CreateGameServer("OuterSpace");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var outerSpace = new OuterSpace();

            var isChangeActiveObject = false;

            outerSpace.OnChangeActiveObject += (e) =>
            {
                Assert.AreEqual(e, 5006);
                isChangeActiveObject = true;
            };

            outerSpace.Refresh(gameSession, new System.Drawing.PointF(10101, 10201), MouseArguments.Move);

            Assert.IsTrue(isChangeActiveObject);

        }

        [TestMethod()]
        public void MouseClickOnObjectAndChangeSelectedObject_Negative_Test()
        {
            var receivedEvents = new List<int>();

            var server = EnvironmentGlobal.CreateGameServer("OuterSpace");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var outerSpace = new OuterSpace();

            var isChangeSelectedObject = false;

            outerSpace.OnChangeSelectedObject += (e) =>
            {
                Assert.AreEqual(e, 5006);
                isChangeSelectedObject = true;
            };

            outerSpace.Refresh(gameSession, new System.Drawing.PointF(9101, 9201), MouseArguments.LeftClick);

            Assert.IsFalse(isChangeSelectedObject);

        }

        [TestMethod()]
        public void MouseClickOnObjectAndChangeActiveObject_Negative_Test()
        {
            var receivedEvents = new List<int>();

            var server = EnvironmentGlobal.CreateGameServer("OuterSpace");

            var gameSession = server.RefreshGameSession(server.SessionId);

            var outerSpace = new OuterSpace();

            var isChangeActiveObject = false;

            outerSpace.OnChangeActiveObject += (e) =>
            {
                if( e > 0)
                    isChangeActiveObject = true;
            };

            outerSpace.Refresh(gameSession, new System.Drawing.PointF(9101, 9201), MouseArguments.Move);

            Assert.IsFalse(isChangeActiveObject);

        }
    }
}