#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{	
	[MapTable("Campeonatos")]
	public partial class Campeonato : MapClass
	{
		#region Miembros
		private int _id_Campeonato;
		private string _nombre;
		private int _id_Division;
		private Division __Division;
		#endregion
		
		#region Constructores
		public Campeonato() : base()
		{}
		
		public Campeonato(MapPrimaryKey mapPrimaryKey) : base(mapPrimaryKey)
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
        [MapPrimaryKeyColumn("Id_Campeonato", Identity=true)]
		public int Id_Campeonato
		{
			get {return _id_Campeonato;}
			set {_id_Campeonato = value;}
		}
		
        [MapColumn("Nombre")]
		public string Nombre
		{
			get {return _nombre;}
			set {_nombre = value;}
		}
		
        [MapForeignKeyColumn("Id_Division", "Id_Division", typeof(Division))]
		public int Id_Division
		{
			get {return _id_Division;}
			set {_id_Division = value;
				__Division = null;}
		}
		
		#region Relaciones
		public Division Division
		{
			get 
			{
				if (__Division == null)
				{
					__Division = Division.Find(_id_Division);
				}
				
				return __Division;
			}
			set 
			{
				__Division = value;
			
				if (value != null)
				{
					_id_Division = __Division.Id_Division;
				}
				else
				{
					_id_Division = 0;
				}
			}			
		}
		
		#endregion
		#endregion
		
		#region Metodos generados
		public override void InitializeProperties()
		{
			_id_Campeonato = 0;
			_nombre = "";
			_id_Division = 0;
		}
		
		public static Campeonato Find(int id_Campeonato)
		{
			return new Campeonato(CreatePrimaryKey(id_Campeonato));
		}
		
		public static MapPrimaryKey CreatePrimaryKey(int id_Campeonato)
		{
			MapPrimaryKey primaryKey = new MapPrimaryKey();
			
			primaryKey.Add("Id_Campeonato", id_Campeonato);
			
			return primaryKey; 
		}  
		#endregion
	}
}
		