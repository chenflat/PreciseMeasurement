using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The AssetattributeInfo class the business object representing a single
	///		Assetattribute object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class AssetattributeInfo {
	
		#region 私有成员
		
			private long _Assetattributeid;
			private string _Assetattrid;
			private string _Attrdescprefix;
			private string _Datatype;
			private string _Description;
			private string _Domainid;
			private string _Measureunitid;
			private bool _Dynamicattr;
			private string _Orgid;
			private string _Siteid;
		
		#endregion
		
		#region 构造方法
		
			public AssetattributeInfo() {
				// default object initialisation
			}
		
			public AssetattributeInfo(string Assetattrid, string Attrdescprefix, string Datatype, string Description, string Domainid, string Measureunitid, bool Dynamicattr, string Orgid, string Siteid) {
				_Assetattrid = Assetattrid;
				_Attrdescprefix = Attrdescprefix;
				_Datatype = Datatype;
				_Description = Description;
				_Domainid = Domainid;
				_Measureunitid = Measureunitid;
				_Dynamicattr = Dynamicattr;
				_Orgid = Orgid;
				_Siteid = Siteid;
			}
		
		#endregion
		
		#region 公有属性
		
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
		
			public string Datatype {
				get	{ return _Datatype; }
				set	{ _Datatype = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public string Domainid {
				get	{ return _Domainid; }
				set	{ _Domainid = value; }
			}
		
			public string Measureunitid {
				get	{ return _Measureunitid; }
				set	{ _Measureunitid = value; }
			}
		
			public bool Dynamicattr {
				get	{ return _Dynamicattr; }
				set	{ _Dynamicattr = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
						
		#endregion
	}
}
