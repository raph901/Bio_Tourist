using Bio_Tourist.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bio_Tourist.ADO
{
    public class ADO_Role
    {
        public static List<Cls_Role> fct_RecupListeObjetRole(SqlDataReader p_DataReader)
        {


            List<Cls_Role> v_ListRole = new List<Cls_Role>();
            while (p_DataReader.Read())
            {
                Cls_Role v_Role = new Cls_Role();
                v_Role.ID_ROLE = Convert.ToInt32(p_DataReader["ID_ROLE"]);
                v_Role.NAME_ROLE = Convert.ToString(p_DataReader["NAME_ROLE"]);

                v_ListRole.Add(v_Role);

            }
            return v_ListRole;

        }      
    }
}