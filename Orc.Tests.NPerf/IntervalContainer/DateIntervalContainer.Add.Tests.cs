﻿namespace Orc.Tests.NPerf.IntervalContainer
{
    using System;

    using Orc.Interface;

    using global::NPerf.Framework;

    [PerfTester(typeof(IIntervalContainer<DateTime>), 2, Description = "Interval Container Add method benchmark tests for DateTime interval", FeatureDescription = "Intervals count")]
    public class DateIntervalContainerAddTests : DateIntervalContainerBenchmarkBase
    {
        [PerfSetUp]
        public void SetUp(int testIndex, IIntervalContainer<DateTime> intervalContainer)
        {
            this.numberOfIntervals = this.CollectionCount(testIndex);
        }

        [PerfRunDescriptor]
        public double RunDescription(int testIndex)
        {
            return this.CollectionCount(testIndex);
        }        

        [PerfTest]
        [PerfIgnore("Should run AccountForEfficienciesTests tests")]
        public void Add_Interval(IIntervalContainer<DateTime> container)
        {
            const int intervalLength = 4;
            const int spaceLength = 1;
            const int intervalAndSpaceLength = intervalLength + spaceLength;
            for (int i = 0; i < this.numberOfIntervals; i++)
            {
                var intervalToAdd = this.ToDateTimeInterval(this.now, i * intervalAndSpaceLength, ((i + 1) * intervalAndSpaceLength) - spaceLength);
                container.Add(intervalToAdd);
            }
        }
    }
}
