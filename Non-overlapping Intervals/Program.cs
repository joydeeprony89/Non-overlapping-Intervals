using System;
using System.Linq;

namespace Non_overlapping_Intervals
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var nums = new int[4][] { new int[] { 1, 100 }, new int[] { 11, 22 }, new int[] { 1, 11 }, new int[] { 2, 12 } };
      var list = nums.ToList();
      var sorted = list.OrderBy(x => x[0]).ThenBy(y => y[1]).ToArray();
      foreach (var s in sorted)
        Console.WriteLine(string.Join(",", s));
    }
  }

  public class Solution
  {
    public int EraseOverlapIntervals(int[][] intervals)
    {
      int count = 0;
      if (intervals.Length == 1) return count;
      // Sort the input based on start time and when tw or more start times are same sort them on end time
      // Example - [[1,100],[11,22],[1,11],[2,12]]
      var list = intervals.ToList();
      var sorted = list.OrderBy(x => x[0]).ThenBy(y => y[1]).ToArray();

      var lastEndTime = sorted[0][1];
      for (int i = 1; i < sorted.Length; i++)
      {
        var current = sorted[i];
        if (current[0] >= lastEndTime)
        {
          // When no overlap, update the end time with current interval end time
          lastEndTime = current[1];
        }
        else
        {
          // When overlap, update lastEndTime with th min(currentEnd, previousEnd);
          // Why? if we choose the interval that ends earlier, then there is more space for other intervals
          lastEndTime = Math.Min(current[1], lastEndTime);
          count++;
        }
      }
      return count;
    }
  }
}
