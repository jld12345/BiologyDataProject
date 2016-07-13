using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace BiologyDepartment
{
    public partial class frmDataLoading : Form
    {
        public event EventHandler<LoadingComplete> FormLoadedEvent;

        public frmDataLoading()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

        }

        public void ProgressBarStep(int step)
        {
            while(pBarDataLoading.Value < step)
                pBarDataLoading.PerformStep();
        }

        public void SetProgressBar()
        {
            pBarDataLoading.Value = 1;
        }

        protected virtual void OnFormLoadedEvent(LoadingComplete e)
        {
            EventHandler<LoadingComplete> handler = FormLoadedEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

    }

    public class LoadingComplete : EventArgs
    {
        private bool bFormLoaded;

        public LoadingComplete(bool isLoaded)
        {
            bFormLoaded = isLoaded;
        }

        public bool IsLoaded
        {
            get { return bFormLoaded; }
        }
    }

}
