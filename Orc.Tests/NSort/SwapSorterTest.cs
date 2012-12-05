namespace Orc.Tests.NSort
{
    using System;

    using NUnit.Framework;

    using Orc.Algorithms.Sort.NSort;

    /// <summary>
	/// Summary description for SwapSorterTest.
	/// </summary>
	[TestFixture]
	public class SwapSorterTest
	{
		public SwapSorter Sorter
		{
			get
			{
				return new BubbleSorter();
			}
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullSwapper()
		{
			SwapSorter sorter = this.Sorter;
			sorter.Swapper = null;
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullComparer()
		{
			SwapSorter sorter = this.Sorter;
			sorter.Comparer = null;
		}
	}
}
