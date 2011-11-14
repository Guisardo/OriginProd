#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{	
	[MapTable("Divisiones")]
	public partial class Division : MapClass
	{
		#region Miembros
		private int _id_Division;
		private string _nombre;
		#endregion
		
		#region Constructores
		public Division() : base()
		{}
		
		public Division(MapPrimaryKey mapPrimaryKey) : base(mapPrimaryKey)
		{}
		
		#endregion
		
		#region Propieades y metodos abstractos
		public override string DaoName
		{
			get
			{
				return DAO.DefaultName;
			}
		}
		#endregion
		
		#region Propiedades
        [MapPrimaryKeyColumn("Id_Division", Identity=true)]
		public int Id_Division
		{
			get {return _id_Division;}
			set {_id_Division = value;}
		}
		
        [MapColumn("Nombre")]
		public string Nombre
		{
			get {return _nombre;}
			set {_nombre = value;}
		}
		
		#region Relaciones
		#endregion
		#endregion
		
		#region Metodos generados
		public override void InitializeProperties()
		{
			_id_Division = 0;
			_nombre = "";
		}
		
		public static Division Find(int id_Division)
		{
			return new Division(CreatePrimaryKey(id_Division));
		}
		
		public static MapPrimaryKey CreatePrimaryKey(int id_Division)
		{
			MapPrimaryKey primaryKey = new MapPrimaryKey();
			
			primaryKey.Add("Id_Division", id_Division);
			
			return primaryKey; 
		}  
		#endregion
	}
}
		