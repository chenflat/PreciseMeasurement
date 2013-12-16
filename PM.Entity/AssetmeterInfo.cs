using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The AssetmeterInfo class the business object representing a single
	///		Assetmeter object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class AssetmeterInfo {
	
		#region 私有成员
		
			private bool _Active;
			private int _Assetmeterid;
			private string _Assetnum;
			private decimal _Average;
			private string _Avgcalcmethod;
			private string _Basemeasureunitid;
			private string _Changeby;
			private DateTime _Changedate;
			private bool _Hasld;
			private string _Langcode;
			private string _Lastreading;
			private DateTime _Lastreadingdate;
			private string _Lastreadinginspctr;
			private decimal _Lifetodate;
			private string _Measureunitid;
			private string _Metername;
			private string _Orgid;
			private string _Pointnum;
			private string _Readingtype;
			private string _Remarks;
			private string _Rolldownsource;
			private decimal _Rollover;
			private int _Sequence;
			private decimal _Sinceinstall;
			private decimal _Sincelastinspect;
			private decimal _Sincelastoverhaul;
			private decimal _Sincelastrepair;
			private string _Siteid;
			private int _Slidingwindowsize;
		
		#endregion
		
		#region 构造方法
		
			public AssetmeterInfo() {
				// default object initialisation
			}
		
			public AssetmeterInfo(bool Active, string Assetnum, decimal Average, string Avgcalcmethod, string Basemeasureunitid, string Changeby, DateTime Changedate, bool Hasld, string Langcode, string Lastreading, DateTime Lastreadingdate, string Lastreadinginspctr, decimal Lifetodate, string Measureunitid, string Metername, string Orgid, string Pointnum, string Readingtype, string Remarks, string Rolldownsource, decimal Rollover, int Sequence, decimal Sinceinstall, decimal Sincelastinspect, decimal Sincelastoverhaul, decimal Sincelastrepair, string Siteid, int Slidingwindowsize) {
				_Active = Active;
				_Assetnum = Assetnum;
				_Average = Average;
				_Avgcalcmethod = Avgcalcmethod;
				_Basemeasureunitid = Basemeasureunitid;
				_Changeby = Changeby;
				_Changedate = Changedate;
				_Hasld = Hasld;
				_Langcode = Langcode;
				_Lastreading = Lastreading;
				_Lastreadingdate = Lastreadingdate;
				_Lastreadinginspctr = Lastreadinginspctr;
				_Lifetodate = Lifetodate;
				_Measureunitid = Measureunitid;
				_Metername = Metername;
				_Orgid = Orgid;
				_Pointnum = Pointnum;
				_Readingtype = Readingtype;
				_Remarks = Remarks;
				_Rolldownsource = Rolldownsource;
				_Rollover = Rollover;
				_Sequence = Sequence;
				_Sinceinstall = Sinceinstall;
				_Sincelastinspect = Sincelastinspect;
				_Sincelastoverhaul = Sincelastoverhaul;
				_Sincelastrepair = Sincelastrepair;
				_Siteid = Siteid;
				_Slidingwindowsize = Slidingwindowsize;
			}
		
		#endregion
		
		#region 公有属性
		
			public bool Active {
				get	{ return _Active; }
				set	{ _Active = value; }
			}
		
			public int Assetmeterid {
				get	{ return _Assetmeterid; }
				set	{ _Assetmeterid = value; }
			}
		
			public string Assetnum {
				get	{ return _Assetnum; }
				set	{ _Assetnum = value; }
			}
		
			public decimal Average {
				get	{ return _Average; }
				set	{ _Average = value; }
			}
		
			public string Avgcalcmethod {
				get	{ return _Avgcalcmethod; }
				set	{ _Avgcalcmethod = value; }
			}
		
			public string Basemeasureunitid {
				get	{ return _Basemeasureunitid; }
				set	{ _Basemeasureunitid = value; }
			}
		
			public string Changeby {
				get	{ return _Changeby; }
				set	{ _Changeby = value; }
			}
		
			public DateTime Changedate {
				get	{ return _Changedate; }
				set	{ _Changedate = value; }
			}
		
			public bool Hasld {
				get	{ return _Hasld; }
				set	{ _Hasld = value; }
			}
		
			public string Langcode {
				get	{ return _Langcode; }
				set	{ _Langcode = value; }
			}
		
			public string Lastreading {
				get	{ return _Lastreading; }
				set	{ _Lastreading = value; }
			}
		
			public DateTime Lastreadingdate {
				get	{ return _Lastreadingdate; }
				set	{ _Lastreadingdate = value; }
			}
		
			public string Lastreadinginspctr {
				get	{ return _Lastreadinginspctr; }
				set	{ _Lastreadinginspctr = value; }
			}
		
			public decimal Lifetodate {
				get	{ return _Lifetodate; }
				set	{ _Lifetodate = value; }
			}
		
			public string Measureunitid {
				get	{ return _Measureunitid; }
				set	{ _Measureunitid = value; }
			}
		
			public string Metername {
				get	{ return _Metername; }
				set	{ _Metername = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Pointnum {
				get	{ return _Pointnum; }
				set	{ _Pointnum = value; }
			}
		
			public string Readingtype {
				get	{ return _Readingtype; }
				set	{ _Readingtype = value; }
			}
		
			public string Remarks {
				get	{ return _Remarks; }
				set	{ _Remarks = value; }
			}
		
			public string Rolldownsource {
				get	{ return _Rolldownsource; }
				set	{ _Rolldownsource = value; }
			}
		
			public decimal Rollover {
				get	{ return _Rollover; }
				set	{ _Rollover = value; }
			}
		
			public int Sequence {
				get	{ return _Sequence; }
				set	{ _Sequence = value; }
			}
		
			public decimal Sinceinstall {
				get	{ return _Sinceinstall; }
				set	{ _Sinceinstall = value; }
			}
		
			public decimal Sincelastinspect {
				get	{ return _Sincelastinspect; }
				set	{ _Sincelastinspect = value; }
			}
		
			public decimal Sincelastoverhaul {
				get	{ return _Sincelastoverhaul; }
				set	{ _Sincelastoverhaul = value; }
			}
		
			public decimal Sincelastrepair {
				get	{ return _Sincelastrepair; }
				set	{ _Sincelastrepair = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
		
			public int Slidingwindowsize {
				get	{ return _Slidingwindowsize; }
				set	{ _Slidingwindowsize = value; }
			}
						
		#endregion
	}
}
