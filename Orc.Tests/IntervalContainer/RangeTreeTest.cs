﻿namespace Orc.Tests.IntervalContainer
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Orc.DataStructures.RangeTree;
    using Orc.Interval.Interface;

    [TestFixture]
    public class RangeTree : DateIntervalContainerTestBase
    {
        protected override IIntervalContainer<DateTime> CreateIntervalContainer(IEnumerable<IInterval<DateTime>> intervals)
        {
            return new RangeTree<DateTime>(intervals);
        }
    }
}
