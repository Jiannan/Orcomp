﻿namespace Orc.Tests.IntervalSkipList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Orc.Entities;
    using Orc.Entities.IntervalSkipList;

    [TestFixture]
    public class IntervalSkipListTest
    {
        private DateTime now;

        protected DateTime inOneHour;

        protected DateTime inTwoHours;

        protected DateTime inThreeHours;

        [SetUp]
        public void Setup()
        {
            now = DateTime.Now;
            inOneHour = now.AddHours(1);
            inTwoHours = now.AddHours(2);
            inThreeHours = now.AddHours(3);
        }

        [TestCase(4, 4, 3)]
        [TestCase(4, 5, 4)]
        [TestCase(-1, 10, 7)]
        [TestCase(-1, -1, 0)]
        [TestCase(1, 4, 5)]
        [TestCase(0, 1, 2)]
        [TestCase(10, 12, 0)]
        public void Search_ForDifferentDateIntervals_ShoudReturnCorrectOverlapsCount(int leftEdgeMinutes, int rightEdgeMinutes, int expectedOverlapsCount)
        {
            //Arrange
            var intervals = new List<Interval<DateTime>>();

            intervals.Add(ToDateTimeInterval(now, -300, -200));
            intervals.Add(ToDateTimeInterval(now, -3, -2));
            intervals.Add(ToDateTimeInterval(now, 1, 2));
            intervals.Add(ToDateTimeInterval(now, 3, 6));
            intervals.Add(ToDateTimeInterval(now, 2, 4));
            intervals.Add(ToDateTimeInterval(now, 5, 7));
            intervals.Add(ToDateTimeInterval(now, 1, 3));
            intervals.Add(ToDateTimeInterval(now, 4, 6));
            intervals.Add(ToDateTimeInterval(now, 8, 9));
            intervals.Add(ToDateTimeInterval(now, 15, 20));
            intervals.Add(ToDateTimeInterval(now, 40, 50));
            intervals.Add(ToDateTimeInterval(now, 49, 60));

            var intervalSkipList = new IntervalSkipList<DateTime>(intervals);

            //Act
            var overlaps = intervalSkipList.Search(ToDateTimeInterval(now, leftEdgeMinutes, rightEdgeMinutes));
            
            //Assert
            Assert.AreEqual(expectedOverlapsCount, overlaps.Count);
        }

        [Test]
        public void Search_ForNullInterval_ShouldReturnEmptyList()
        {
            //Arrange
            var intervalList = new List<Interval<DateTime>>();
            intervalList.Add(new Interval<DateTime>(now, inOneHour));
                        
            var intervals = new IntervalSkipList<DateTime>(intervalList);

            //Act
            var intersections = intervals.Search(null);

            //Assert
            Assert.AreEqual(0, intersections.Count);
        }

        [Test]
        public void Search_IntervalBetweenTwoInclusiveIntervals_ShouldReturnBothIntervals()
        {
            //Arrange
            var intervalList = new List<Interval<DateTime>>();
            intervalList.Add(new Interval<DateTime>(now, inOneHour, isMaxInclusive: false));
            intervalList.Add(new Interval<DateTime>(inTwoHours, inThreeHours, isMinInclusive: false));

            var intervals = new IntervalSkipList<DateTime>(intervalList);

            //Act
            var intersections = intervals.Search(new Interval<DateTime>(inOneHour, inTwoHours));

            //Assert
            CollectionAssert.AreEquivalent(intervalList, intersections.ToList());
        }

        [Test]
        public void Search_IntervalBetweenTwoNotInclusiveIntervals_ShouldReturnEmptyList()
        {
            //Arrange
            var intervalList = new List<Interval<DateTime>>();
            intervalList.Add(new DateInterval(now, inOneHour, isMaxInclusive: false));
            intervalList.Add(new DateInterval(inTwoHours, inThreeHours, isMinInclusive: false));

            var intervals = new IntervalSkipList<DateTime>(intervalList);

            //Act
            var intersections = intervals.Search(new Interval<DateTime>(inOneHour, inTwoHours));

            //Assert
            Assert.AreEqual(0, intersections.Count);
        }

        private static Interval<DateTime> ToDateTimeInterval(DateTime startTime, int leftEdgeMinutes, int rightEdgeMinutes)
        {
            return new Interval<DateTime>(startTime.AddMinutes(leftEdgeMinutes), startTime.AddMinutes(rightEdgeMinutes));
        }
    }
}
