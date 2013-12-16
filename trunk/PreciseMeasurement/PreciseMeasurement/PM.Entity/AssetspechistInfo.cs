using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The AssetspechistInfo class the business object representing a single
	///		Assetspechist object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class AssetspechistInfo {
	
		#region 私有成员
		
			private string _Alnvalue;
			private string _Assetattrid;
			private string _Assetnum;
			private long _Assetspechistid;
			private long _Assetspecid;
			private string _Basemeasureunitid;
			private string _Changeby;
			private DateTime _Changedate;
			private long _Classspecid;
			private string _Classstructureid;
			private DateTime _Createddate;
			private int _Displaysequence;
			private string _Linkedtoattribute;
			private string _Linkedtosection;
			private bool _Mandatory;
			private string _Measureunitid;
			private decimal _Numvalue;
			private string _Orgid;
			private DateTime _Removeddate;
			private string _Section;
			private string _Siteid;
		
		#endregion
		
		#region 构造方法
		
			public AssetspechistInfo() {
				// default object initialisation
			}
		
			public AssetspechistInfo(string Alnvalue, string Assetattrid, string Assetnum, long Assetspecid, string Basemeasureunitid, string Changeby, DateTime Changedate, long Classspecid, string Classstructureid, DateTime Createddate, int Displaysequence, string Linkedtoattribute, string Linkedtosection, bool Mandatory, string Measureunitid, decimal Numvalue, string Orgid, DateTime Removeddate, string Section, string Siteid) {
				_Alnvalue = Alnvalue;
				_Assetattrid = Assetattrid;
				_Assetnum = Assetnum;
				_Assetspecid = Assetspecid;
				_Basemeasureunitid = Basemeasureunitid;
				_Changeby = Changeby;
				_Changedate = Changedate;
				_Classspecid = Classspecid;
				_Classstructureid = Classstructureid;
				_Createddate = Createddate;
				_Displaysequence = Displaysequence;
				_Linkedtoattribute = Linkedtoattribute;
				_Linkedtosection = Linkedtosection;
				_Mandatory = Mandatory;
				_Measureunitid = Measureunitid;
				_Numvalue = Numvalue;
				_Orgid = Orgid;
				_Removeddate = Removeddate;
				_Section = Section;
				_Siteid = Siteid;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Alnvalue {
				get	{ return _Alnvalue; }
				set	{ _Alnvalue = value; }
			}
		
			public string Assetattrid {
				get	{ return _Assetattrid; }
				set	{ _Assetattrid = value; }
			}
		
			public string Assetnum {
				get	{ return _Assetnum; }
				set	{ _Assetnum = value; }
			}
		
			public long Assetspechistid {
				get	{ return _Assetspechistid; }
				set	{ _Assetspechistid = value; }
			}
		
			public long Assetspecid {
				get	{ return _Assetspecid; }
				set	{ _Assetspecid = value; }
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
		
			public long Classspecid {
				get	{ return _Classspecid; }
				set	{ _Classspecid = value; }
			}
		
			public string Classstructureid {
				get	{ return _Classstructureid; }
				set	{ _Classstructureid = value; }
			}
		
			public DateTime Createddate {
				get	{ return _Createddate; }
				set	{ _Createddate = value; }
			}
		
			public int Displaysequence {
				get	{ return _Displaysequence; }
				set	{ _Displaysequence = value; }
			}
		
			public string Linkedtoattribute {
				get	{ return _Linkedtoattribute; }
				set	{ _Linkedtoattribute = value; }
			}
		
			public string Linkedtosection {
				get	{ return _Linkedtosection; }
				set	{ _Linkedtosection = value; }
			}
		
			public bool Mandatory {
				get	{ return _Mandatory; }
				set	{ _Mandatory = value; }
			}
		
			public string Measureunitid {
				get	{ return _Measureunitid; }
				set	{ _Measureunitid = value; }
			}
		
			public decimal Numvalue {
				get	{ return _Numvalue; }
				set	{ _Numvalue = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public DateTime Removeddate {
				get	{ return _Removeddate; }
				set	{ _Removeddate = value; }
			}
		
			public string Section {
				get	{ return _Section; }
				set	{ _Section = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
						
		#endregion
	}
}
