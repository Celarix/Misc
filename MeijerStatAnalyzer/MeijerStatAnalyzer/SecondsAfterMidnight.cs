﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerStatAnalyzer
{
	public struct SecondsAfterMidnight : IComparable<SecondsAfterMidnight>
	{
		private int seconds;

		public int Seconds
		{
			get
			{
				return seconds;
			}
			private set
			{
				seconds = value;
			}
		}

		public SecondsAfterMidnight(int seconds)
		{
			this.seconds = seconds;
		}

		public SecondsAfterMidnight(TimeSpan span)
		{
			seconds = (int)span.TotalSeconds;
		}

		public SecondsAfterMidnight(DateTime dateTime) : this(dateTime.Hour, dateTime.Minute, dateTime.Second)
		{
		}

		public SecondsAfterMidnight(int hours, int minutes, int seconds)
		{
			this.seconds = hours * 3600;
			this.seconds += minutes * 60;
			this.seconds += seconds;
		}

		public DateTime ToDateTime()
		{
			int year = DateTime.Now.Year;
			int month = DateTime.Now.Month;
			int day = DateTime.Now.Day;
			DateTime todayMidnight = new DateTime(year, month, day);
			return todayMidnight + TimeSpan.FromSeconds(Seconds);
		}

		public string ToTimeString()
		{
			return ToDateTime().ToLongTimeString();
		}

		public override string ToString()
		{
			return $"{ToDateTime().ToShortTimeString()}";
		}

		public override int GetHashCode()
		{
			return seconds;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is SecondsAfterMidnight)) { return false; }
			else
			{
				var that = (SecondsAfterMidnight)obj;
				return seconds == that.seconds;
			}
		}

		public int CompareTo(SecondsAfterMidnight other)
		{
			return seconds.CompareTo(other.seconds);
		}

		public static bool operator ==(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds == b.seconds;
		public static bool operator !=(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds != b.seconds;
		public static bool operator <(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds < b.seconds;
		public static bool operator >(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds > b.seconds;
		public static bool operator <=(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds <= b.seconds;
		public static bool operator >=(SecondsAfterMidnight a, SecondsAfterMidnight b) => a.seconds >= b.seconds;
	}
}
