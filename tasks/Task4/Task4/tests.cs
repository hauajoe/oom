using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Tests
{
    [TestFixture]
    class tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }
    }
    class Movietest
    {
        [Test]
        public void CreateMovie()
        {
            Movie t1 = new Movie("Testfilm", 999, 9);
            Assert.IsTrue(t1.getTitle() == "Testfilm");
            Assert.IsTrue(t1.getLength() == 999);
            Assert.IsTrue(t1.getWatchcount() == 9);
        }
    }
    class Tvshowtest
    {
        [Test]
        public void CreateTvshow()
        {
            Tvshow t2 = new Tvshow("Testserie", 99);
            Assert.IsTrue(t2.getTitle() == "Testserie");
            Assert.IsTrue(t2.getEpisodes() == 99);
        }
    }
    class IncorrectMovie
    {
        [Test]
        public void NoTitle()
        {
            Assert.Catch(() =>
            {
                Movie t3 = new Movie("", 999, 9);
            });
        }
        [Test]
        public void NoDuration()
        {
            Assert.Catch(() =>
            {
                Movie t4 = new Movie("Test", -999, 9);
            });
        }
        [Test]
        public void NoCount()
        {
            Assert.Catch(() =>
            {
                Movie t5 = new Movie("Test", 999, -9);
            });
        }
    }
}
