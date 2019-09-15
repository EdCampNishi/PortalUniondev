using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD.Interfaces;

namespace UnionDev.Models.BD.Factory
{
    class DataBaseFactory
    {
        public static IDataBase CreateDBUNIONDEV()
        {
            return new UNIONDEVDataBase();
        }
    }
}