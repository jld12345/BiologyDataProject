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

        public List<PDFClass> BulkExport()
        {
            List<PDFClass> lstPDF = GlobalVariables.GlobalConnection.BulkExportPDF();
            return lstPDF;
        }

        public void InsertPDF(PDFClass thePDF)
        {
            NpgsqlCMD = new NpgsqlCommand();
            NpgsqlCMD.CommandText = @"INSERT INTO EXPERIMENT_PDF 
                                      (EXPERIMENT_PDF_ID, EXPERIMENT_ID, EXPERIMENT_PDF_TITLE, EXPERIMENT_PDF_DESCRIPTION,
                                        EXPERIMENT_PDF)
                                      VALUES(nextval('EXPERIMENT_PDF_ID_SEQ'), :EX_ID, :TITLE, :DESC, :PDF)";

            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("TITLE", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("DESC", NpgsqlDbType.Varchar));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("EX_ID", NpgsqlDbType.Integer));
            NpgsqlCMD.Parameters.Add(new NpgsqlParameter("PDF", NpgsqlDbType.Bytea));
            NpgsqlCMD.Parameters[0].Value = thePDF.EXPERIMENT_PDF_TITLE;
            NpgsqlCMD.Parameters[1].Value = thePDF.EXPERIMENT_PDF_DESCRIPTION;
            NpgsqlCMD.Parameters[2].Value = thePDF.EXPERIMENT_ID;
            NpgsqlCMD.Parameters[3].Value = thePDF.EXPERIMENT_PDF;


            if (GlobalVariables.GlobalConnection.insertData(NpgsqlCMD))
                MessageBox.Show("Picture successfully inserted.", "Picture Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error inserting picture.", "Insert Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
