using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BiologyDepartment
{
    class daoChart
    {
        private DataSet ds = new DataSet();
        private NpgsqlCommand NpgsqlCMD;

        public daoChart()
        {
        }

        public DataSet getBarChartData(int id, string filters)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = @"select ROUND(AVG(FISH_WEIGHT_LENGTH.FISH_LENGTH), 2) as FLENGTH, 
                                ROUND(AVG(FISH_WEIGHT_LENGTH.WT_WEIGHT * 1000), 2) as WEIGHT, 
                                FISH_WEIGHT_LENGTH.WEEK as WEEK, FISH_WEIGHT_LENGTH.COLOR as C,
                                DIET_TABLE.OMEGA_3_6_RATIO as RATIO, DIET_TABLE.DIET_NAME as DIET,
                                DIET_TABLE.FAT_PERCENT as FAT, NVL(FISH_WEIGHT_LENGTH.SEX, 'U') as SEX,
                                ROUND(STDDEV(FISH_WEIGHT_LENGTH.WT_WEIGHT * 1000)/
                                SQRT(count(1)),2) as ERR_MEAN_WEIGHT,
                                ROUND(STDDEV(FISH_WEIGHT_LENGTH.FISH_LENGTH)/
                                SQRT(count(1)),2) as ERR_MEAN_LENGTH
                                from FISH_WEIGHT_LENGTH, DIET_TABLE, DE_TABLE
                                where FISH_FISH_WEIGHT_LENGTH.EX_ID = :id
                                and FISH_WEIGHT_LENGTH.EX_ID = DE_TABLE.EX_ID
                                and DE_TABLE.DIET_ID = DIET_TABLE.DIET_ID
                                and FISH_WEIGHT_LENGTH.COLOR = DE_TABLE.COLOR "
                                + filters + @"
                                group by FISH_WEIGHT_LENGTH.WEEK, FISH_WEIGHT_LENGTH.COLOR, DIET_TABLE.OMEGA_3_6_RATIO, 
                                DIET_TABLE.FAT_PERCENT, FISH_WEIGHT_LENGTH.SEX, DIET_TABLE.DIET_NAME
                                order by FAT, RATIO"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", id));
 
            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public DataSet getColor(int id)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = "select distinct(COLOR) FROM FISH_WEIGHT_LENGTH WHERE EX_ID = :id order by COLOR asc"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", id));

            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public DataSet getWeek(int id)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = "select distinct(WEEK) FROM FISH_WEIGHT_LENGTH WHERE EX_ID = :id order by WEEK asc"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", id));
            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);
            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }

        public DataSet getRData(int id)
        {
            NpgsqlCMD = new NpgsqlCommand()
            {
                CommandText = @"select ROUND(AVG(FISH_WEIGHT_LENGTH.FISH_LENGTH),2) as FLENGTH, 
                                ROUND(AVG(FISH_WEIGHT_LENGTH.WT_WEIGHT * 1000),2) as WEIGHT, 
                                FISH_WEIGHT_LENGTH.WEEK as WEEK, FISH_WEIGHT_LENGTH.COLOR as C,
                                DIET_TABLE.OMEGA_3_6_RATIO as RATIO, DIET_TABLE.DIET_NAME as DIET,
                                DIET_TABLE.FAT_PERCENT as FAT, NVL(FISH_WEIGHT_LENGTH.SEX, 'U') as SEX
                                from FISH_WEIGHT_LENGTH, DIET_TABLE, DE_TABLE
                                where FISH_WEIGHT_LENGTH.EX_ID = :id 
                                and FISH_WEIGHT_LENGTH.EX_ID = DE_TABLE.EX_ID
                                and DE_TABLE.DIET_ID = DIET_TABLE.DIET_ID
                                and FISH_WEIGHT_LENGTH.COLOR = DE_TABLE.COLOR
                                and FISH_WEIGHT_LENGTH.WEEK = 'T'
                                and FISH_WEIGHT_LENGTH.WT_WEIGHT is not null
                                group by FISH_WEIGHT_LENGTH.WEEK, FISH_WEIGHT_LENGTH.COLOR,
                                DIET_TABLE.OMEGA_3_6_RATIO, DIET_TABLE.DIET_NAME,
                                DIET_TABLE.FAT_PERCENT, FISH_WEIGHT_LENGTH.SEX
                                order by FISH_WEIGHT_LENGTH.COLOR ASC"
            };
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", id));
            ds = new DataSet();
            ds = GlobalVariables.GlobalConnection.ReadData(NpgsqlCMD);

            if (ds != null)
            {
                return ds;
            }
            else
                return null;
        }
    }
}
