using Npgsql;
using NpgsqlTypes;
using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BiologyDepartment
{
    class daoSetup
    {
        private NpgsqlCommand NpgsqlCMD;
        public int InsertColumn(int EXID, string colName, string colType, string sDescription, string sFormula)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_CUSTOM_COLUMNS 
                                      (EX_ID, CUSTOM_COLUMNS_ID, CUSTOM_COLUMN_NAME, CUSTOM_COLUMN_DATA_TYPE, Custom_Column_Comments, CUSTOM_COLUMN_FORMULA)
                                      VALUES(:id, NEXTVAL('EXPERIMENT_CUSTOM_COLUMN_ID_SEQ'), :colName, :colType, :sDesc, :formula);
                                      select currval('EXPERIMENT_CUSTOM_COLUMN_ID_SEQ');";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colType", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":sDesc", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":formula", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = EXID;
            NpgsqlCMD.Parameters[1].Value = colName;
            NpgsqlCMD.Parameters[2].Value = colType;
            NpgsqlCMD.Parameters[3].Value = sDescription;
            NpgsqlCMD.Parameters[4].Value = sFormula;

            return GlobalVariables.GlobalConnection.InsertDataAndGetID(NpgsqlCMD);
        }

        public void UpdateColumn(int ColID, string colName, string colType, string sDescription, string sFormula)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"UPDATE EXPERIMENT_CUSTOM_COLUMNS 
                                      SET   CUSTOM_COLUMN_NAME = :colName, 
                                            CUSTOM_COLUMN_DATA_TYPE = :colType,
                                            CUSTOM_COLUMN_COMMENTS = :sDesc,
                                            CUSTOM_COLUMN_FORMULA = :formula
                                      WHERE CUSTOM_COLUMNS_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colName", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":colType", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":sDesc", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":formula", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = ColID;
            NpgsqlCMD.Parameters[1].Value = colName;
            NpgsqlCMD.Parameters[2].Value = colType;
            NpgsqlCMD.Parameters[3].Value = sDescription;
            NpgsqlCMD.Parameters[4].Value = sFormula;

            GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD);
        }

        public void DeleteColumn(int ColID)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"DELETE FROM EXPERIMENT_CUSTOM_COLUMNS
                                      WHERE CUSTOM_COLUMNS_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = ColID;

            GlobalVariables.GlobalConnection.DeleteData(NpgsqlCMD);
        }

        public DataTable GetExperimentColumns(int EXID)
        {
            NpgsqlCMD = new NpgsqlCommand();    
            NpgsqlCMD.CommandText = @"SELECT *, '' map_column FROM EXPERIMENT_CUSTOM_COLUMNS
                                      WHERE EX_ID = :id";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = EXID;

            return GlobalVariables.GlobalConnection.ReadDataTable(NpgsqlCMD);
        }

        public int GetNewRowID()
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_CORE_COLUMNS 
                                      (EX_CORE_COL_ID, EX_ID, MODIFIED_USER, MODIFIED_DATE)
                                      VALUES(NEXTVAL('EXPERIMENT_CORE_COLUMNS_ID_SEQ'),:id, :moduser, LOCALTIMESTAMP);
                                      select currval('EXPERIMENT_CORE_COLUMNS_ID_SEQ');";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = GlobalVariables.Experiment.ID;
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":moduser", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[1].Value = GlobalVariables.ADUserName;
            //NpgsqlCMD.Parameters.Add(new NpgsqlParameter("uploadTime", NpgsqlDbType.Timestamp));
            //NpgsqlCMD.Parameters[2].Value = DateTime.Now();

            return GlobalVariables.GlobalConnection.InsertDataAndGetID(NpgsqlCMD);
        }

        public void InsertRowValue(int rowID, int nCusColumnID, string sInputData, string sAggData)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_DATA
                                      (EXPERIMENT_DATA_ID, EX_CORE_COL_ID, CUSTOM_COLUMNS_ID, CUSTOM_COLUMN_DATA, DATA_AGG)
                                      VALUES(NEXTVAL('EXPERIMENT_DATA_ID_SEQ'),:rowID, :id, :theData, :theDataAgg);";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":id", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = nCusColumnID;
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":theData", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[1].Value = sInputData;
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":theDataAgg", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[2].Value = sAggData;
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter(":rowID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[3].Value = rowID;

            GlobalVariables.GlobalConnection.InsertData(NpgsqlCMD);
        }

        public void BulkImport(List<string> ImportRows)
        {
            GlobalVariables.GlobalConnection.BulkInsertData(ImportRows);
        }

        public int GetExperimentDataRowID()
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"SELECT NEXTVAL('EXPERIMENT_DATA_ID_SEQ');";
            return GlobalVariables.GlobalConnection.InsertDataAndGetID(NpgsqlCMD);
        }
    }
}
