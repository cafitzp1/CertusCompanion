using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    public partial class Test : Form
    {
        MyRenderer myRenderer;
        Image img = CertusCompanion.Properties.Resources.dropDownMouseOverIcon;
        Image img2 = CertusCompanion.Properties.Resources.dropDownSelectedIcon;
        Image imgToUse;
        private bool contextMenuOpened;

        public Test()
        {
            InitializeComponent();

            myRenderer = new MyRenderer();
            customDDLMenuStrip.Renderer = myRenderer;
            imgToUse = img;
        }



        // --- CUSTOM DROP DOWN --- //

        private void customDDLBtns_MouseDown(object sender, MouseEventArgs e) //* 
        {
            if (contextMenuOpened)
            {
                customDDLPanel_Leave(sender, e);
                contextMenuOpened = false;
                return;
            }

            imgToUse = img2;
            customDDLPanel_Enter(sender, e);

            // specific to each DDL
            customDDLMenuStrip.Show(t4OuterPanel, new Point(-1, t4OuterPanel.Height - 2));
        }

        private void customDDLPanel_Enter(object sender, EventArgs e) //* 
        {
            customDDLPanel_MouseHover(sender, e);

            t4OuterPanel.MouseLeave -= customDDLPanel_MouseLeave;
            t4SelectionBtn.MouseLeave -= customDDLPanel_MouseLeave;
            t4DropBtn.MouseLeave -= customDDLPanel_MouseLeave;

            // specific to each DDL
            customDDLMenuStrip.MouseLeave -= customDDLPanel_MouseLeave;
        }

        private void customDDLPanel_MouseHover(object sender, EventArgs e)
        {
            // mouse over effect
            t4SelectionBtn.BackColor = Color.FromArgb(40,40,40);
            t4SplitPanel.Visible = true;
            t4DropBtn.BackgroundImage = imgToUse;
        }

        private void customDDLPanel_MouseLeave(object sender, EventArgs e)
        {
            // mouse off effect
            t4SelectionBtn.BackColor = Color.FromArgb(27,27,27);
            t4SplitPanel.Visible = false;
            t4DropBtn.BackgroundImage = CertusCompanion.Properties.Resources.dropDownIcon;
            imgToUse = img;
        }

        private void customDDLPanel_MouseMove(object sender, MouseEventArgs e)
        {
            customDDLPanel_MouseHover(sender, e);
        }

        private void customDDLPanel_Leave(object sender, EventArgs e) //* 
        {
            t4OuterPanel.MouseLeave += customDDLPanel_MouseLeave;
            t4DropBtn.MouseLeave += customDDLPanel_MouseLeave;
            t4SelectionBtn.MouseLeave += customDDLPanel_MouseLeave;

            // specific to each DDL
            customDDLMenuStrip.MouseLeave += customDDLPanel_MouseLeave;

            customDDLPanel_MouseLeave(sender, e);
        }

        private void customDDLContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            t4SelectionBtn.Text = e.ClickedItem.Text;
            customDDLPanel_MouseLeave(sender, e);
            contextMenuOpened = false;
        }

        private void customDDLContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            customDDLPanel_Leave(sender, e);
            preventDropDownReopen.Enabled = true;
        }

        private void customDDLContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            contextMenuOpened = true;
        }

        private void customDDLPreventDropDownReopen_Tick(object sender, EventArgs e)
        {
            preventDropDownReopen.Enabled = false;
            contextMenuOpened = false;
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
