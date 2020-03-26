using Bio_Tourist.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bio_Tourist.ADO
{
    public class ADO_GENDER
    {
        public static List<Cls_GENDER> fct_RecupListeObjetGENDER(SqlDataReader p_DataReader)
        {


            List<Cls_GENDER> v_ListGENDER = new List<Cls_GENDER>();
            while (p_DataReader.Read())
            {
                Cls_GENDER v_GENDER = new Cls_GENDER();
                v_GENDER.ID_GENDER = Convert.ToInt32(p_DataReader["ID_GENDER"]);
                v_GENDER.NAME_GENDER = Convert.ToString(p_DataReader["NAME_GENDER"]);

                v_ListGENDER.Add(v_GENDER);

            }
            return v_ListGENDER;

        }
        //fonction qui permet la Recuperation Des objet GENDER
        public static Cls_GENDER fct_RecupObjetGENDER(SqlDataReader p_DataReader)
        {
            while (p_DataReader.Read())
            {
                Cls_GENDER v_ObjGENDER = new Cls_GENDER();
                v_ObjGENDER.ID_GENDER = Convert.ToInt32(p_DataReader["ID_GENDER"]);
                v_ObjGENDER.NAME_GENDER = Convert.ToString(p_DataReader["NAME_GENDER"]);
                return v_ObjGENDER;

            }
            return null;

        }
    }
}