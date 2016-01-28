using Npgsql;
using NpgsqlTypes;
using System.Data;
using System;

namespace BiologyDepartment
{
    class daoSetup
    {
        private NpgsqlCommand NpgsqlCMD;
        public int InsertColumn(int EXID, string colName, string colType)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_CUSTOM_COLUMNS 
                                      (EX_ID, CUSTOM_COLUMNS_ID, CUSTOM_COLUMN_NAME, CUSTOM_COLUMN_DATA_TYPE)
                                      VALUES(:id, NEXTVAL('EXPERIMENT_CUSTOM_COLUMN_ID_SEQ'), :colName, :colType);
                                      select currval('EXPERIMENT_CUSTOM_COLUMN_ID_SEQ');";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colType", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = EXID;
            NpgsqlCMD.Parameters[1].Value = colName;
            NpgsqlCMD.Parameters[2].Value = colType;

            return GlobalVariables.GlobalConnection.InsertDataAndGetID(NpgsqlCMD);
        }

        public void UpdateColumn(int ColID, string colName, string colType)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"UPDATE EXPERIMENT_CUSTOM_COLUMNS 
                                      SET   CUSTOM_COLUMN_NAME = :colName, 
                                            CUSTOM_COLUMN_DATA_TYPE = :colType,
                                      WHERE CUSTOM_COLUMNS_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colType", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = ColID;
            NpgsqlCMD.Parameters[1].Value = colName;
            NpgsqlCMD.Parameters[2].Value = colType;

            GlobalVariables.GlobalConnection.updateData(NpgsqlCMD);
        }

        public void DeleteColumn(int ColID)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"DELETE FROM EXPERIMENT_CUSTOM_COLUMNS
                                      WHERE CUSTOM_COLUMNS_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = ColID;

            GlobalVariables.GlobalConnection.deleteData(NpgsqlCMD);
        }

        public DataTable GetExperimentColumns(int EXID)
        {
            NpgsqlCMD = new NpgsqlCommand();    
            NpgsqlCMD.CommandText = @"SELECT * FROM EXPERIMENT_CUSTOM_COLUMNS
                                      WHERE EX_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = EXID;

            return GlobalVariables.GlobalConnection.readDataTable(NpgsqlCMD);
        }
    }
}
