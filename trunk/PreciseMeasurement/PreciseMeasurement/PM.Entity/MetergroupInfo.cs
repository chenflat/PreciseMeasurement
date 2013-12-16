using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The MetergroupInfo class the business object representing a single
	///		Metergroup object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class MetergroupInfo {
	
		#region 私有成员
		
			private string _Description;
			private string _Groupname;
			private bool _Hasld;
			private string _Langcode;
			private long _Metergroupid;
		
		#endregion
		
		#region 构造方法
		
			public MetergroupInfo() {
				// default object initialisation
			}
		
			public MetergroupInfo(string Description, string Groupname, bool Hasld, string Langcode) {
				_Description = Description;
				_Groupname = Groupname;
				_Hasld = Hasld;
				_Langcode = Langcode;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public string Groupname {
				get	{ return _Groupname; }
				set	{ _Groupname = value; }
			}
		
			public bool Hasld {
				get	{ return _Hasld; }
				set	{ _Hasld = value; }
			}
		
			public string Langcode {
				get	{ return _Langcode; }
				set	{ _Langcode = value; }
			}
		
			public long Metergroupid {
				get	{ return _Metergroupid; }
				set	{ _Metergroupid = value; }
			}
						
		#endregion
	}
}
