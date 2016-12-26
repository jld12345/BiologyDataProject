using System;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace BiologyDepartment.ExperimentDocuments
{
    public class DocumentDAO
    {
        private NpgsqlCommand NpgsqlCMD;
        private NpgsqlDataAdapter adapter;

        public DocumentDAO()
        {

        }

        public List<DocumentTreeNode> BulkExport()
        {
            List<DocumentTreeNode> lstPDF = GlobalVariables.GlobalConnection.BulkExportPDF();
            return lstPDF;
        }

        public void InsertPDF(DocumentClass thePDF)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_DOCUMENT 
                                      (EXPERIMENT_DOCUMENT_ID, EXPERIMENT_ID, EXPERIMENT_DOCUMENT_TITLE, EXPERIMENT_DOCUMENT_DESCRIPTION,
                                        EXPERIMENT_DOCUMENT_TYPE, EXPERIMENT_DOCUMENT)
                                      VALUES(nextval('EXPERIMENT_DOCUMENT_ID_SEQ'), :EX_ID, :TITLE, :DESC, :DOCTYPE, :PDF)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("TITLE", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DESC", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("EX_ID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DOCTYPE", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("PDF", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = thePDF.DOCUMENT_TITLE;
            NpgsqlCMD.Parameters[1].Value = thePDF.DOCUMENT_DESCRIPTION;
            NpgsqlCMD.Parameters[2].Value = thePDF.EXPERIMENT_ID;
            NpgsqlCMD.Parameters[3].Value = thePDF.DOCUMENT_TYPE;
            NpgsqlCMD.Parameters[4].Value = thePDF.DOCUMENT;


            if (GlobalVariables.GlobalConnection.InsertData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void UpdatePDF(DocumentClass thePDF)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"UPDATE EXPERIMENT_DOCUMENT 
                                      SET EXPERIMENT_DOCUMENT_TITLE = :TITLE, 
                                          EXPERIMENT_DOCUMENT_DESCRIPTION = :DESC,
                                          EXPERIMENT_DOCUMENT_TYPE = :DOCTYPE
                                       WHERE EXPERIMENT_DOCUMENT_ID = :DOCID";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("TITLE", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DESC", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DOCID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DOCTYPE", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters[0].Value = thePDF.DOCUMENT_TITLE;
            NpgsqlCMD.Parameters[1].Value = thePDF.DOCUMENT_DESCRIPTION;
            NpgsqlCMD.Parameters[2].Value = thePDF.DOCUMENT_ID;
            NpgsqlCMD.Parameters[3].Value = thePDF.DOCUMENT_TYPE;

            if (GlobalVariables.GlobalConnection.UpdateData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void DeletePDF(DocumentClass thePDF)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"DELETE FROM  EXPERIMENT_DOCUMENT 
                                       WHERE EXPERIMENT_DOCUMENT_ID = :DOCID";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DOCID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters[0].Value = thePDF.DOCUMENT_ID;
            GlobalVariables.GlobalConnection.DeleteData(NpgsqlCMD);
        }
    }
}
