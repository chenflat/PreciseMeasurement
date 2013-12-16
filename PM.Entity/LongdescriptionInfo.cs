using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The LongdescriptionInfo class the business object representing a single
	///		Longdescription object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class LongdescriptionInfo {
	
		#region 私有成员
		
			private long _Longdescriptionid;
			private long _Ldkey;
			private string _Ldownertable;
			private string _Ldownercole;
			private string _Ldtext;
			private string _Langcode;
			private string _Contentuid;
		
		#endregion
		
		#region 构造方法
		
			public LongdescriptionInfo() {
				// default object initialisation
			}
		
			public LongdescriptionInfo(long Ldkey, string Ldownertable, string Ldownercole, string Ldtext, string Langcode, string Contentuid) {
				_Ldkey = Ldkey;
				_Ldownertable = Ldownertable;
				_Ldownercole = Ldownercole;
				_Ldtext = Ldtext;
				_Langcode = Langcode;
				_Contentuid = Contentuid;
			}
		
		#endregion
		
		#region 公有属性
		
			public long Longdescriptionid {
				get	{ return _Longdescriptionid; }
				set	{ _Longdescriptionid = value; }
			}
		
			public long Ldkey {
				get	{ return _Ldkey; }
				set	{ _Ldkey = value; }
			}
		
			public string Ldownertable {
				get	{ return _Ldownertable; }
				set	{ _Ldownertable = value; }
			}
		
			public string Ldownercole {
				get	{ return _Ldownercole; }
				set	{ _Ldownercole = value; }
			}
		
			public string Ldtext {
				get	{ return _Ldtext; }
				set	{ _Ldtext = value; }
			}
		
			public string Langcode {
				get	{ return _Langcode; }
				set	{ _Langcode = value; }
			}
		
			public string Contentuid {
				get	{ return _Contentuid; }
				set	{ _Contentuid = value; }
			}
						
		#endregion
	}
}
