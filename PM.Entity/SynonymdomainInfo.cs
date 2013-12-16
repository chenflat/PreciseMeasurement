using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The SynonymdomainInfo class the business object representing a single
	///		Synonymdomain object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class SynonymdomainInfo {
	
		#region 私有成员
		
			private bool _Defaults;
			private string _Description;
			private string _Domainid;
			private string _Orgid;
			private string _Siteid;
			private long _Synonymdomainid;
			private string _Value;
			private string _Valueid;
		
		#endregion
		
		#region 构造方法
		
			public SynonymdomainInfo() {
				// default object initialisation
			}
		
			public SynonymdomainInfo(bool Defaults, string Description, string Domainid, string Orgid, string Siteid, string Value, string Valueid) {
				_Defaults = Defaults;
				_Description = Description;
				_Domainid = Domainid;
				_Orgid = Orgid;
				_Siteid = Siteid;
				_Value = Value;
				_Valueid = Valueid;
			}
		
		#endregion
		
		#region 公有属性
		
			public bool Defaults {
				get	{ return _Defaults; }
				set	{ _Defaults = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public string Domainid {
				get	{ return _Domainid; }
				set	{ _Domainid = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
		
			public long Synonymdomainid {
				get	{ return _Synonymdomainid; }
				set	{ _Synonymdomainid = value; }
			}
		
			public string Value {
				get	{ return _Value; }
				set	{ _Value = value; }
			}
		
			public string Valueid {
				get	{ return _Valueid; }
				set	{ _Valueid = value; }
			}
						
		#endregion
	}
}
