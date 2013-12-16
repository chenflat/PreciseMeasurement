using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The ClassificationInfo class the business object representing a single
	///		Classification object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class ClassificationInfo {
	
		#region 私有成员
		
			private string _Classificationid;
			private long _Classificationuid;
			private string _Description;
			private bool _Hasld;
			private string _Orgid;
			private string _Siteid;
		
		#endregion
		
		#region 构造方法
		
			public ClassificationInfo() {
				// default object initialisation
			}
		
			public ClassificationInfo(string Classificationid, string Description, bool Hasld, string Orgid, string Siteid) {
				_Classificationid = Classificationid;
				_Description = Description;
				_Hasld = Hasld;
				_Orgid = Orgid;
				_Siteid = Siteid;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Classificationid {
				get	{ return _Classificationid; }
				set	{ _Classificationid = value; }
			}
		
			public long Classificationuid {
				get	{ return _Classificationuid; }
				set	{ _Classificationuid = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public bool Hasld {
				get	{ return _Hasld; }
				set	{ _Hasld = value; }
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
