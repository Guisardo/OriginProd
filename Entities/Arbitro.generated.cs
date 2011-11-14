#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{	
	[MapTable("Arbitros")]
	public partial class Arbitro : MapClass
	{
		#region Miembros
		private int _id_Arbitro;
		private string _nombre;
		#endregion
		
		#region Constructores
		public Arbitro() : base()
		{}
		
		public Arbitro(MapPrimaryKey mapPrimaryKey) : base(mapPrimaryKey)
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
        [MapPrimaryKeyColumn("Id_Arbitro", Identity=true)]
		public int Id_Arbitro
		{
			get {return _id_Arbitro;}
			set {_id_Arbitro = value;}
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
			_id_Arbitro = 0;
			_nombre = "";
		}
		
		public static Arbitro Find(int id_Arbitro)
		{
			return new Arbitro(CreatePrimaryKey(id_Arbitro));
		}
		
		public static MapPrimaryKey CreatePrimaryKey(int id_Arbitro)
		{
			MapPrimaryKey primaryKey = new MapPrimaryKey();
			
			primaryKey.Add("Id_Arbitro", id_Arbitro);
			
			return primaryKey; 
		}  
		#endregion
	}
}
		