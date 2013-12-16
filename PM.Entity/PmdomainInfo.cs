using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The PmdomainInfo class the business object representing a single
	///		Pmdomain object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class PmdomainInfo {
	
		#region 私有成员
		
			private string _Domainid;
			private string _Description;
			private string _Domaintype;
			private string _Systype;
			private long _Sysdomainid;
			private int _Length;
		
		#endregion
		
		#region 构造方法
		
			public PmdomainInfo() {
				// default object initialisation
			}
		
			public PmdomainInfo(string Domainid, string Description, string Domaintype, string Systype, int Length) {
				_Domainid = Domainid;
				_Description = Description;
				_Domaintype = Domaintype;
				_Systype = Systype;
				_Length = Length;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Domainid {
				get	{ return _Domainid; }
				set	{ _Domainid = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public string Domaintype {
				get	{ return _Domaintype; }
				set	{ _Domaintype = value; }
			}
		
			public string Systype {
				get	{ return _Systype; }
				set	{ _Systype = value; }
			}
		
			public long Sysdomainid {
				get	{ return _Sysdomainid; }
				set	{ _Sysdomainid = value; }
			}
		
			public int Length {
				get	{ return _Length; }
				set	{ _Length = value; }
			}
						
		#endregion
	}
}
