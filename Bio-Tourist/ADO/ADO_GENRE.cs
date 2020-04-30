using Bio_Tourist.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bio_Tourist.ADO
{
    public class ADO_GENRE
    {
        public static List<Cls_GENRE> fct_RecupListeObjetGENRE(SqlDataReader p_DataReader)
        {


            List<Cls_GENRE> v_ListGENRE = new List<Cls_GENRE>();
            while (p_DataReader.Read())
            {
                Cls_GENRE v_GENRE = new Cls_GENRE();
                v_GENRE.ID_GENDER = Convert.ToInt32(p_DataReader["ID_GENDER"]);
                v_GENRE.NAME_GENDER = Convert.ToString(p_DataReader["NAME_GENDER"]);

                v_ListGENRE.Add(v_GENRE);

            }
            return v_ListGENRE;

        }    
    }
}