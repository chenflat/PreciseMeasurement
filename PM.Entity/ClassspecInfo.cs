using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The ClassspecInfo class the business object representing a single
	///		Classspec object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class ClassspecInfo {
	
		#region 私有成员
		
			private bool _Applydownhier;
			private long _Assetattributeid;
			private string _Assetattrid;
			private string _Attrdescprefix;
			private long _Classspecid;
			private string _Classstructureid;
			private string _Domainid;
			private string _Inheritedfrom;
			private int _Inheritedfromid;
			private string _Lookupname;
			private string _Measureunitid;
			private string _Orgid;
			private string _Section;
			private string _Siteid;
			private string _Tableattribute;
		
		#endregion
		
		#region 构造方法
		
			public ClassspecInfo() {
				// default object initialisation
			}
		
			public ClassspecInfo(bool Applydownhier, long Assetattributeid, string Assetattrid, string Attrdescprefix, string Classstructureid, string Domainid, string Inheritedfrom, int Inheritedfromid, string Lookupname, string Measureunitid, string Orgid, string Section, string Siteid, string Tableattribute) {
				_Applydownhier = Applydownhier;
				_Assetattributeid = Assetattributeid;
				_Assetattrid = Assetattrid;
				_Attrdescprefix = Attrdescprefix;
				_Classstructureid = Classstructureid;
				_Domainid = Domainid;
				_Inheritedfrom = Inheritedfrom;
				_Inheritedfromid = Inheritedfromid;
				_Lookupname = Lookupname;
				_Measureunitid = Measureunitid;
				_Orgid = Orgid;
				_Section = Section;
				_Siteid = Siteid;
				_Tableattribute = Tableattribute;
			}
		
		#endregion
		
		#region 公有属性
		
			public bool Applydownhier {
				get	{ return _Applydownhier; }
				set	{ _Applydownhier = value; }
			}
		
			public long Assetattributeid {
				get	{ return _Assetattributeid; }
				set	{ _Assetattributeid = value; }
			}
		
			public string Assetattrid {
				get	{ return _Assetattrid; }
				set	{ _Assetattrid = value; }
			}
		
			public string Attrdescprefix {
				get	{ return _Attrdescprefix; }
				set	{ _Attrdescprefix = value; }
			}
		
			public long Classspecid {
				get	{ return _Classspecid; }
				set	{ _Classspecid = value; }
			}
		
			public string Classstructureid {
				get	{ return _Classstructureid; }
				set	{ _Classstructureid = value; }
			}
		
			public string Domainid {
				get	{ return _Domainid; }
				set	{ _Domainid = value; }
			}
		
			public string Inheritedfrom {
				get	{ return _Inheritedfrom; }
				set	{ _Inheritedfrom = value; }
			}
		
			public int Inheritedfromid {
				get	{ return _Inheritedfromid; }
				set	{ _Inheritedfromid = value; }
			}
		
			public string Lookupname {
				get	{ return _Lookupname; }
				set	{ _Lookupname = value; }
			}
		
			public string Measureunitid {
				get	{ return _Measureunitid; }
				set	{ _Measureunitid = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Section {
				get	{ return _Section; }
				set	{ _Section = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
		
			public string Tableattribute {
				get	{ return _Tableattribute; }
				set	{ _Tableattribute = value; }
			}
						
		#endregion
	}
}
