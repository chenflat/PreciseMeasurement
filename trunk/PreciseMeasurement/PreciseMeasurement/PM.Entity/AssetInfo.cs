using System;

namespace PM.Entity
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	///		The AssetInfo class the business object representing a single
	///		Asset object, as used by the Entity module.
	/// </summary>
	/// <history>
	///		@Author [CHEN PING]	
	///     @version 2013-12-16 21:06:34 
	/// </history>
	/// -----------------------------------------------------------------------------
	[Serializable]
	public class AssetInfo {
	
		#region 私有成员
		
			private long _Assetuid;
			private string _Ancestor;
			private long _Assetid;
			private string _Assetnum;
			private string _Assettag;
			private string _Assettype;
			private string _Specclass;
			private string _Calnum;
			private string _Changeby;
			private DateTime _Changedate;
			private string _Classstructureid;
			private string _Description;
			private bool _Disabled;
			private string _Externalrefid;
			private string _Failurecode;
			private string _Groupname;
			private bool _Haschildren;
			private bool _Hasmoredesc;
			private DateTime _Installdate;
			private bool _Isrunning;
			private string _Langcode;
			private string _Location;
			private bool _Mainthierchy;
			private string _Manufacturer;
			private bool _Moved;
			private string _Orgid;
			private string _Ownersysid;
			private string _Parent;
			private int _Priority;
			private string _Sendersysid;
			private string _Serialnum;
			private string _Shiftnum;
			private string _Siteid;
			private string _Sourcesysid;
			private string _Status;
			private DateTime _Statusdate;
			private string _Usage;
			private string _Vendor;
			private DateTime _Warrantyexpdate;
			private string _Ec1;
			private string _Ec2;
			private string _Ec3;
			private string _Ec4;
			private decimal _Ec5;
			private DateTime _Ec6;
			private decimal _Ec7;
			private string _Ec8;
			private string _Ec9;
			private string _Ec10;
			private string _Ec11;
			private decimal _Ec12;
			private DateTime _Ec13;
			private string _Ec14;
			private decimal _Ec15;
		
		#endregion
		
		#region 构造方法
		
			public AssetInfo() {
				// default object initialisation
			}
		
			public AssetInfo(string Ancestor, long Assetid, string Assetnum, string Assettag, string Assettype, string Specclass, string Calnum, string Changeby, DateTime Changedate, string Classstructureid, string Description, bool Disabled, string Externalrefid, string Failurecode, string Groupname, bool Haschildren, bool Hasmoredesc, DateTime Installdate, bool Isrunning, string Langcode, string Location, bool Mainthierchy, string Manufacturer, bool Moved, string Orgid, string Ownersysid, string Parent, int Priority, string Sendersysid, string Serialnum, string Shiftnum, string Siteid, string Sourcesysid, string Status, DateTime Statusdate, string Usage, string Vendor, DateTime Warrantyexpdate, string Ec1, string Ec2, string Ec3, string Ec4, decimal Ec5, DateTime Ec6, decimal Ec7, string Ec8, string Ec9, string Ec10, string Ec11, decimal Ec12, DateTime Ec13, string Ec14, decimal Ec15) {
				_Ancestor = Ancestor;
				_Assetid = Assetid;
				_Assetnum = Assetnum;
				_Assettag = Assettag;
				_Assettype = Assettype;
				_Specclass = Specclass;
				_Calnum = Calnum;
				_Changeby = Changeby;
				_Changedate = Changedate;
				_Classstructureid = Classstructureid;
				_Description = Description;
				_Disabled = Disabled;
				_Externalrefid = Externalrefid;
				_Failurecode = Failurecode;
				_Groupname = Groupname;
				_Haschildren = Haschildren;
				_Hasmoredesc = Hasmoredesc;
				_Installdate = Installdate;
				_Isrunning = Isrunning;
				_Langcode = Langcode;
				_Location = Location;
				_Mainthierchy = Mainthierchy;
				_Manufacturer = Manufacturer;
				_Moved = Moved;
				_Orgid = Orgid;
				_Ownersysid = Ownersysid;
				_Parent = Parent;
				_Priority = Priority;
				_Sendersysid = Sendersysid;
				_Serialnum = Serialnum;
				_Shiftnum = Shiftnum;
				_Siteid = Siteid;
				_Sourcesysid = Sourcesysid;
				_Status = Status;
				_Statusdate = Statusdate;
				_Usage = Usage;
				_Vendor = Vendor;
				_Warrantyexpdate = Warrantyexpdate;
				_Ec1 = Ec1;
				_Ec2 = Ec2;
				_Ec3 = Ec3;
				_Ec4 = Ec4;
				_Ec5 = Ec5;
				_Ec6 = Ec6;
				_Ec7 = Ec7;
				_Ec8 = Ec8;
				_Ec9 = Ec9;
				_Ec10 = Ec10;
				_Ec11 = Ec11;
				_Ec12 = Ec12;
				_Ec13 = Ec13;
				_Ec14 = Ec14;
				_Ec15 = Ec15;
			}
		
		#endregion
		
		#region 公有属性
		
			public long Assetuid {
				get	{ return _Assetuid; }
				set	{ _Assetuid = value; }
			}
		
			public string Ancestor {
				get	{ return _Ancestor; }
				set	{ _Ancestor = value; }
			}
		
			public long Assetid {
				get	{ return _Assetid; }
				set	{ _Assetid = value; }
			}
		
			public string Assetnum {
				get	{ return _Assetnum; }
				set	{ _Assetnum = value; }
			}
		
			public string Assettag {
				get	{ return _Assettag; }
				set	{ _Assettag = value; }
			}
		
			public string Assettype {
				get	{ return _Assettype; }
				set	{ _Assettype = value; }
			}
		
			public string Specclass {
				get	{ return _Specclass; }
				set	{ _Specclass = value; }
			}
		
			public string Calnum {
				get	{ return _Calnum; }
				set	{ _Calnum = value; }
			}
		
			public string Changeby {
				get	{ return _Changeby; }
				set	{ _Changeby = value; }
			}
		
			public DateTime Changedate {
				get	{ return _Changedate; }
				set	{ _Changedate = value; }
			}
		
			public string Classstructureid {
				get	{ return _Classstructureid; }
				set	{ _Classstructureid = value; }
			}
		
			public string Description {
				get	{ return _Description; }
				set	{ _Description = value; }
			}
		
			public bool Disabled {
				get	{ return _Disabled; }
				set	{ _Disabled = value; }
			}
		
			public string Externalrefid {
				get	{ return _Externalrefid; }
				set	{ _Externalrefid = value; }
			}
		
			public string Failurecode {
				get	{ return _Failurecode; }
				set	{ _Failurecode = value; }
			}
		
			public string Groupname {
				get	{ return _Groupname; }
				set	{ _Groupname = value; }
			}
		
			public bool Haschildren {
				get	{ return _Haschildren; }
				set	{ _Haschildren = value; }
			}
		
			public bool Hasmoredesc {
				get	{ return _Hasmoredesc; }
				set	{ _Hasmoredesc = value; }
			}
		
			public DateTime Installdate {
				get	{ return _Installdate; }
				set	{ _Installdate = value; }
			}
		
			public bool Isrunning {
				get	{ return _Isrunning; }
				set	{ _Isrunning = value; }
			}
		
			public string Langcode {
				get	{ return _Langcode; }
				set	{ _Langcode = value; }
			}
		
			public string Location {
				get	{ return _Location; }
				set	{ _Location = value; }
			}
		
			public bool Mainthierchy {
				get	{ return _Mainthierchy; }
				set	{ _Mainthierchy = value; }
			}
		
			public string Manufacturer {
				get	{ return _Manufacturer; }
				set	{ _Manufacturer = value; }
			}
		
			public bool Moved {
				get	{ return _Moved; }
				set	{ _Moved = value; }
			}
		
			public string Orgid {
				get	{ return _Orgid; }
				set	{ _Orgid = value; }
			}
		
			public string Ownersysid {
				get	{ return _Ownersysid; }
				set	{ _Ownersysid = value; }
			}
		
			public string Parent {
				get	{ return _Parent; }
				set	{ _Parent = value; }
			}
		
			public int Priority {
				get	{ return _Priority; }
				set	{ _Priority = value; }
			}
		
			public string Sendersysid {
				get	{ return _Sendersysid; }
				set	{ _Sendersysid = value; }
			}
		
			public string Serialnum {
				get	{ return _Serialnum; }
				set	{ _Serialnum = value; }
			}
		
			public string Shiftnum {
				get	{ return _Shiftnum; }
				set	{ _Shiftnum = value; }
			}
		
			public string Siteid {
				get	{ return _Siteid; }
				set	{ _Siteid = value; }
			}
		
			public string Sourcesysid {
				get	{ return _Sourcesysid; }
				set	{ _Sourcesysid = value; }
			}
		
			public string Status {
				get	{ return _Status; }
				set	{ _Status = value; }
			}
		
			public DateTime Statusdate {
				get	{ return _Statusdate; }
				set	{ _Statusdate = value; }
			}
		
			public string Usage {
				get	{ return _Usage; }
				set	{ _Usage = value; }
			}
		
			public string Vendor {
				get	{ return _Vendor; }
				set	{ _Vendor = value; }
			}
		
			public DateTime Warrantyexpdate {
				get	{ return _Warrantyexpdate; }
				set	{ _Warrantyexpdate = value; }
			}
		
			public string Ec1 {
				get	{ return _Ec1; }
				set	{ _Ec1 = value; }
			}
		
			public string Ec2 {
				get	{ return _Ec2; }
				set	{ _Ec2 = value; }
			}
		
			public string Ec3 {
				get	{ return _Ec3; }
				set	{ _Ec3 = value; }
			}
		
			public string Ec4 {
				get	{ return _Ec4; }
				set	{ _Ec4 = value; }
			}
		
			public decimal Ec5 {
				get	{ return _Ec5; }
				set	{ _Ec5 = value; }
			}
		
			public DateTime Ec6 {
				get	{ return _Ec6; }
				set	{ _Ec6 = value; }
			}
		
			public decimal Ec7 {
				get	{ return _Ec7; }
				set	{ _Ec7 = value; }
			}
		
			public string Ec8 {
				get	{ return _Ec8; }
				set	{ _Ec8 = value; }
			}
		
			public string Ec9 {
				get	{ return _Ec9; }
				set	{ _Ec9 = value; }
			}
		
			public string Ec10 {
				get	{ return _Ec10; }
				set	{ _Ec10 = value; }
			}
		
			public string Ec11 {
				get	{ return _Ec11; }
				set	{ _Ec11 = value; }
			}
		
			public decimal Ec12 {
				get	{ return _Ec12; }
				set	{ _Ec12 = value; }
			}
		
			public DateTime Ec13 {
				get	{ return _Ec13; }
				set	{ _Ec13 = value; }
			}
		
			public string Ec14 {
				get	{ return _Ec14; }
				set	{ _Ec14 = value; }
			}
		
			public decimal Ec15 {
				get	{ return _Ec15; }
				set	{ _Ec15 = value; }
			}
						
		#endregion
	}
}
