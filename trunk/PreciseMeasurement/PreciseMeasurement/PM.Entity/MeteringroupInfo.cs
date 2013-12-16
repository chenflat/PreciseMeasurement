using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The MeteringroupInfo class the business object representing a single
	///		Meteringroup object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class MeteringroupInfo {
	
		#region 私有成员
		
			private string _Avgcalcmethod;
			private string _Groupname;
			private long _Meteringroupid;
			private string _Metername;
			private decimal _Rollover;
			private int _Sequence;
			private int _Slidingwindowsize;
			private decimal _Staticaverage;
		
		#endregion
		
		#region 构造方法
		
			public MeteringroupInfo() {
				// default object initialisation
			}
		
			public MeteringroupInfo(string Avgcalcmethod, string Groupname, string Metername, decimal Rollover, int Sequence, int Slidingwindowsize, decimal Staticaverage) {
				_Avgcalcmethod = Avgcalcmethod;
				_Groupname = Groupname;
				_Metername = Metername;
				_Rollover = Rollover;
				_Sequence = Sequence;
				_Slidingwindowsize = Slidingwindowsize;
				_Staticaverage = Staticaverage;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Avgcalcmethod {
				get	{ return _Avgcalcmethod; }
				set	{ _Avgcalcmethod = value; }
			}
		
			public string Groupname {
				get	{ return _Groupname; }
				set	{ _Groupname = value; }
			}
		
			public long Meteringroupid {
				get	{ return _Meteringroupid; }
				set	{ _Meteringroupid = value; }
			}
		
			public string Metername {
				get	{ return _Metername; }
				set	{ _Metername = value; }
			}
		
			public decimal Rollover {
				get	{ return _Rollover; }
				set	{ _Rollover = value; }
			}
		
			public int Sequence {
				get	{ return _Sequence; }
				set	{ _Sequence = value; }
			}
		
			public int Slidingwindowsize {
				get	{ return _Slidingwindowsize; }
				set	{ _Slidingwindowsize = value; }
			}
		
			public decimal Staticaverage {
				get	{ return _Staticaverage; }
				set	{ _Staticaverage = value; }
			}
						
		#endregion
	}
}
