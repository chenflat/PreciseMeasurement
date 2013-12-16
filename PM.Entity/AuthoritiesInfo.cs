using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The AuthoritiesInfo class the business object representing a single
	///		Authorities object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class AuthoritiesInfo {
	
		#region 私有成员
		
			private int _Authority_id;
			private string _Authority_name;
			private int _Parent;
			private int _Authority_type;
			private int _Priority;
			private string _Authority_url;
			private string _Description;
			private bool _Enabled;
		
		#endregion
		
		#region 构造方法
		
			public AuthoritiesInfo() {
				// default object initialisation
			}
		
			public AuthoritiesInfo(string Authority_name, int Parent, int Authority_type, int Priority, string Authority_url, string Description, bool Enabled) {
				_Authority_name = Authority_name;
				_Parent = Parent;
				_Authority_type = Authority_type;
				_Priority = Priority;
				_Authority_url = Authority_url;
				_Description = Description;
				_Enabled = Enabled;
			}
		
		#endregion
		
		#region 公有属性
		
			public int Authority_id {
				get	{ return _Authority_id; }
				set	{ _Authority_id = value; }
			}
		
			public string Authority_name {
				get	{ return _Authority_name; }
				set	{ _Authority_name = value; }
			}
		
			public int Parent {
				get	{ return _Parent; }
				set	{ _Parent = value; }
			}
		
			public int Authority_type {
				get	{ return _Authority_type; }
				set	{ _Authority_type = value; }
			}
		
			public int Priority {
				get	{ return _Priority; }
				set	{ _Priority = value; }
			}
		
			public string Authority_url {
				get	{ return _Authority_url; }
				set	{ _Authority_url = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public bool Enabled {
				get	{ return _Enabled; }
				set	{ _Enabled = value; }
			}
						
		#endregion
	}
}
