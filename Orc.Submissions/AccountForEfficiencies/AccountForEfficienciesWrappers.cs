﻿namespace Orc.Submissions
{
    using System.Collections.Generic;

    using Orc.Entities;
    using Orc.Interface;

    public class vrstks_AccountForEfficiencies : IAccountForEfficiencies
    {
        public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
        {
            return initialInterval.vrstks(dateIntervalEfficiencies, fixedEndPoint);
        }
    }

    public class vrstks2_AccountForEfficiencies : IAccountForEfficiencies
    {
        public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
        {
            return initialInterval.vrstks2(dateIntervalEfficiencies, fixedEndPoint);
        }
    }

    public class thcristo_AccountForEfficiencies : IAccountForEfficiencies
    {
        public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
        {
            return initialInterval.thcristo(dateIntervalEfficiencies, fixedEndPoint);
        }
    }

    public class thcristo2_AccountForEfficiencies: IAccountForEfficiencies
    {
        public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
        {
            return initialInterval.thcristo2(dateIntervalEfficiencies, fixedEndPoint);
        }
    }

    //public class Quicks01lver2_AccountForEfficiencies : IAccountForEfficienciesWrapper
    //{
    //    public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
    //    {
    //        return initialInterval.Quicks01lver2(dateIntervalEfficiencies, fixedEndPoint);
    //    }
    //}

    public class MoustafaS_AccountForEfficiencies : IAccountForEfficiencies
    {
        public DateInterval AccountForEfficiencies(DateInterval initialInterval, List<DateIntervalEfficiency> dateIntervalEfficiencies, FixedEndPoint fixedEndPoint)
        {
            return initialInterval.MoustafaS(dateIntervalEfficiencies, fixedEndPoint);
        }
    }
}