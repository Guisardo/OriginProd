#region Usings
using System.Data;
using System;
using System.Collections;
using Sopp.Map;
#endregion

namespace OriginProd.Entities
{
    public class DAO
    {
        private static string _default = "default";

        public static MapDao Get(string key)
        {
            return MapDao.Get(key);
        }

        public static string DefaultName
        {
            get { return _default; }
            set { _default = value; }
        }

        public static MapDao Default
        {
            get { return MapDao.Get(_default); }
        }
    }
}
