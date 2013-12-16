using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The ClassstructureInfo class the business object representing a single
	///		Classstructure object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class ClassstructureInfo {
	
		#region 私有成员
		
			private string _Classificationid;
			private string _Classstructureid;
			private long _Classstructureuid;
			private string _Description;
			private bool _Genassetdesc;
			private bool _Haschildren;
			private bool _Hasld;
			private string _Langcode;
			private string _Orgid;
			private string _Parent;
			private string _Siteid;
			private string _Type;
			private bool _Useclassindesc;
		
		#endregion
		
		#region 构造方法
		
			public ClassstructureInfo() {
				// default object initialisation
			}
		
			public ClassstructureInfo(string Classificationid, string Classstructureid, string Description, bool Genassetdesc, bool Haschildren, bool Hasld, string Langcode, string Orgid, string Parent, string Siteid, string Type, bool Useclassindesc) {
				_Classificationid = Classificationid;
				_Classstructureid = Classstructureid;
				_Description = Description;
				_Genassetdesc = Genassetdesc;
				_Haschildren = Haschildren;
				_Hasld = Hasld;
				_Langcode = Langcode;
				_Orgid = Orgid;
				_Parent = Parent;
				_Siteid = Siteid;
				_Type = Type;
				_Useclassindesc = Useclassindesc;
			}
		
		#endregion
		
		#region 公有属性
		
			public string Classificationid {
				get	{ return _Classificationid; }
				set	{ _Classificationid = value; }
			}
		
			public string Classstructureid {
				get	{ return _Classstructureid; }
				set	{ _Classstructureid = value; }
			}
		
			public long Classstructureuid {
				get	{ return _Classstructureuid; }
				set	{ _Classstructureuid = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public bool Genassetdesc {
				get	{ return _Genassetdesc; }
				set	{ _Genassetdesc = value; }
			}
		
			public bool Haschildren {
				get	{ return _Haschildren; }
				set	{ _Haschildren = value; }
			}
		
			public bool Hasld {
				get	{ return _Hasld; }
				set	{ _Hasld = value; }
			}
		
			public string Langcode {
				get	{ return _Langcode; }
				set	{ _Langcode = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Parent {
				get	{ return _Parent; }
				set	{ _Parent = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
		
			public string Type {
				get	{ return _Type; }
				set	{ _Type = value; }
			}
		
			public bool Useclassindesc {
				get	{ return _Useclassindesc; }
				set	{ _Useclassindesc = value; }
			}
						
		#endregion
	}
}
