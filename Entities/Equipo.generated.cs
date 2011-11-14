#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{	
	[MapTable("Equipos")]
	public partial class Equipo : MapClass
	{
		#region Miembros
		private int _id_Equipo;
		private string _nombre;
		#endregion
		
		#region Constructores
		public Equipo() : base()
		{}
		
		public Equipo(MapPrimaryKey mapPrimaryKey) : base(mapPrimaryKey)
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
        [MapPrimaryKeyColumn("Id_Equipo", Identity=true)]
		public int Id_Equipo
		{
			get {return _id_Equipo;}
			set {_id_Equipo = value;}
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
			_id_Equipo = 0;
			_nombre = "";
		}
		
		public static Equipo Find(int id_Equipo)
		{
			return new Equipo(CreatePrimaryKey(id_Equipo));
		}
		
		public static MapPrimaryKey CreatePrimaryKey(int id_Equipo)
		{
			MapPrimaryKey primaryKey = new MapPrimaryKey();
			
			primaryKey.Add("Id_Equipo", id_Equipo);
			
			return primaryKey; 
		}  
		#endregion
	}
}
		