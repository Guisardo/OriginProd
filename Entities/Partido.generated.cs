#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{	
	[MapTable("Partidos")]
	public partial class Partido : MapClass
	{
		#region Miembros
		private int _id_Partido;
		private int _id_EquipoLocal;
		private int _id_EquipoVisitante;
		private int _golesLocales;
		private int _golesVisitantes;
		private int _fechaNumero;
		private int _id_Campeonato;
		private int _id_Arbitro;
		private System.Boolean _esProde;
		private Arbitro __Arbitro;
		private Campeonato __Campeonato;
		private Equipo __EquipoLocal;
		private Equipo __EquipoVisitante;
		#endregion
		
		#region Constructores
		public Partido() : base()
		{}
		
		public Partido(MapPrimaryKey mapPrimaryKey) : base(mapPrimaryKey)
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
        [MapPrimaryKeyColumn("Id_Partido", Identity=true)]
		public int Id_Partido
		{
			get {return _id_Partido;}
			set {_id_Partido = value;}
		}
		
        [MapForeignKeyColumn("Id_EquipoLocal", "Id_Equipo", typeof(Equipo))]
		public int Id_EquipoLocal
		{
			get {return _id_EquipoLocal;}
			set {_id_EquipoLocal = value;
				__EquipoLocal = null;}
		}
		
        [MapForeignKeyColumn("Id_EquipoVisitante", "Id_Equipo", typeof(Equipo))]
		public int Id_EquipoVisitante
		{
			get {return _id_EquipoVisitante;}
			set {_id_EquipoVisitante = value;
				__EquipoVisitante = null;}
		}
		
        [MapColumn("GolesLocales")]
		public int GolesLocales
		{
			get {return _golesLocales;}
			set {_golesLocales = value;}
		}
		
        [MapColumn("GolesVisitantes")]
		public int GolesVisitantes
		{
			get {return _golesVisitantes;}
			set {_golesVisitantes = value;}
		}
		
        [MapColumn("FechaNumero")]
		public int FechaNumero
		{
			get {return _fechaNumero;}
			set {_fechaNumero = value;}
		}
		
        [MapForeignKeyColumn("Id_Campeonato", "Id_Campeonato", typeof(Campeonato))]
		public int Id_Campeonato
		{
			get {return _id_Campeonato;}
			set {_id_Campeonato = value;
				__Campeonato = null;}
		}
		
        [MapForeignKeyColumn("Id_Arbitro", "Id_Arbitro", typeof(Arbitro))]
		public int Id_Arbitro
		{
			get {return _id_Arbitro;}
			set {_id_Arbitro = value;
				__Arbitro = null;}
		}
		
        [MapColumn("EsProde")]
		public System.Boolean EsProde
		{
			get {return _esProde;}
			set {_esProde = value;}
		}
		
		#region Relaciones
		public Arbitro Arbitro
		{
			get 
			{
				if (__Arbitro == null)
				{
					__Arbitro = Arbitro.Find(_id_Arbitro);
				}
				
				return __Arbitro;
			}
			set 
			{
				__Arbitro = value;
			
				if (value != null)
				{
					_id_Arbitro = __Arbitro.Id_Arbitro;
				}
				else
				{
					_id_Arbitro = 0;
				}
			}			
		}
		
		public Campeonato Campeonato
		{
			get 
			{
				if (__Campeonato == null)
				{
					__Campeonato = Campeonato.Find(_id_Campeonato);
				}
				
				return __Campeonato;
			}
			set 
			{
				__Campeonato = value;
			
				if (value != null)
				{
					_id_Campeonato = __Campeonato.Id_Campeonato;
				}
				else
				{
					_id_Campeonato = 0;
				}
			}			
		}
		
		public Equipo EquipoLocal
		{
			get 
			{
				if (__EquipoLocal == null)
				{
					__EquipoLocal = Equipo.Find(_id_EquipoLocal);
				}
				
				return __EquipoLocal;
			}
			set 
			{
				__EquipoLocal = value;
			
				if (value != null)
				{
					_id_EquipoLocal = __EquipoLocal.Id_Equipo;
				}
				else
				{
					_id_EquipoLocal = 0;
				}
			}			
		}
		
		public Equipo EquipoVisitante
		{
			get 
			{
				if (__EquipoVisitante == null)
				{
					__EquipoVisitante = Equipo.Find(_id_EquipoVisitante);
				}
				
				return __EquipoVisitante;
			}
			set 
			{
				__EquipoVisitante = value;
			
				if (value != null)
				{
					_id_EquipoVisitante = __EquipoVisitante.Id_Equipo;
				}
				else
				{
					_id_EquipoVisitante = 0;
				}
			}			
		}
		
		#endregion
		#endregion
		
		#region Metodos generados
		public override void InitializeProperties()
		{
			_id_Partido = 0;
			_id_EquipoLocal = 0;
			_id_EquipoVisitante = 0;
			_golesLocales = 0;
			_golesVisitantes = 0;
			_fechaNumero = 0;
			_id_Campeonato = 0;
			_id_Arbitro = 0;
			_esProde = false;
		}
		
		public static Partido Find(int id_Partido)
		{
			return new Partido(CreatePrimaryKey(id_Partido));
		}
		
		public static MapPrimaryKey CreatePrimaryKey(int id_Partido)
		{
			MapPrimaryKey primaryKey = new MapPrimaryKey();
			
			primaryKey.Add("Id_Partido", id_Partido);
			
			return primaryKey; 
		}  
		#endregion
	}
}
		