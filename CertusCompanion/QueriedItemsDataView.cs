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
    public delegate void QueriedItemEventHandler(object sender, string docItemID);

    public partial class QueriedItemsDataView : Form
    {
        List<WorkflowItem> workflowItemsList;
        ListViewItem previousItem;
        ListViewHitTestInfo hoverItem;
        ListViewHitTestInfo clickedItem;
        int previousIndex = -1;

        public event QueriedItemEventHandler ListViewDoubleClicked;

        public QueriedItemsDataView()
        {
            InitializeComponent();
            previousItem = new ListViewItem();
            this.Size = new Size(1290, 350+20);     
        }

        private void queriedItemsListView_MouseMove(object sender, MouseEventArgs e)
        {
            hoverItem = queriedItemsListView.HitTest(e.Location);
            if (hoverItem.SubItem != null && hoverItem.SubItem == hoverItem.Item.SubItems[15])
            {
                queriedItemsListView.Cursor = Cursors.Hand;
            }
            else queriedItemsListView.Cursor = Cursors.Default;
        }

        private void queriedItemsListView_MouseClick(object sender, MouseEventArgs e)
        {
            clickedItem = queriedItemsListView.HitTest(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                //place menu at the pointer position
                listboxContextMenuStrip.Show(this, new Point(e.X+7, e.Y+8));
            }
            if (clickedItem.SubItem != null && clickedItem.SubItem.Text != String.Empty && clickedItem.SubItem == clickedItem.Item.SubItems[15])
            {
                Cursor.Current = Cursors.WaitCursor;
                string targetURL = clickedItem.Item.SubItems[15].Text;

                System.Diagnostics.Process.Start(targetURL);
                Cursor.Current = Cursors.Default;
            }
        }

        private void queriedItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            clickedItem = queriedItemsListView.HitTest(e.Location);
            string docID = clickedItem.Item.SubItems[1].Text;

            if (ListViewDoubleClicked != null)
                ListViewDoubleClicked(this, docID);
        }

        private void openDataInNewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queriedItemsListView_MouseDoubleClick(this, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedItem.SubItem != null && clickedItem.SubItem.Text != String.Empty)
            {
                Clipboard.SetText(clickedItem.SubItem.Text);
            }
        }

        private void queriedItemsListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void queriedItemsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (!(previousIndex > e.ItemIndex))
            {
                e.DrawDefault = true;
                e.Item.BackColor = Color.FromArgb(255, 255, 255, 255);
                e.Item.UseItemStyleForSubItems = true;

                if (previousItem.Text != String.Empty && previousItem.SubItems[9].Text == e.Item.SubItems[9].Text)
                {
                    e.Item.BackColor = previousItem.BackColor;
                    e.Item.UseItemStyleForSubItems = true;
                }
                else if (previousItem.Text != String.Empty && previousItem.BackColor == e.Item.BackColor)
                {
                    if (previousItem.BackColor == Color.FromArgb(255, 255, 255, 255))
                    {
                        e.Item.BackColor = Color.FromArgb(230, 230, 255);
                        e.Item.UseItemStyleForSubItems = true;
                    }
                    else if (previousItem.BackColor == Color.FromArgb(230, 230, 255))
                    {
                        e.Item.BackColor = Color.FromArgb(255, 255, 255, 255);
                        e.Item.UseItemStyleForSubItems = true;
                    }
                }
            }
            else
            {
                e.DrawDefault=true;
            }


            previousItem = e.Item;
            previousIndex = e.ItemIndex;
        }

        private void queriedItemsListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender != queriedItemsListView) return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                string fullString = queriedItemsListView.SelectedItems[0].SubItems[14].ToString();
                string subString = fullString.Substring(18, fullString.Length-19);
                Clipboard.SetText(subString);
            }
        }

        public void PopulateData(List<WorkflowItem> queriedItemsList)
        {
            int itemNum = 1;
            this.queriedItemsListView.Items.Clear();

            foreach (WorkflowItem o in queriedItemsList)
            {
                workflowItemsList = queriedItemsList;

                ListViewItem item = new ListViewItem(itemNum.ToString());
                item.SubItems.Add(o.DocumentWorkflowItemID.ToString());
                item.SubItems.Add(o.ContractID);
                item.SubItems.Add(o.VendorName);
                item.SubItems.Add(o.Active.ToString());
                item.SubItems.Add(o.Compliant.ToString());
                item.SubItems.Add(o.NextExpirationDate.ToString());
                item.SubItems.Add(o.WorkflowAnalyst);
                item.SubItems.Add(o.CompanyAnalyst);
                item.SubItems.Add(o.EmailDate.ToString());
                item.SubItems.Add(o.EmailFromAddress);
                item.SubItems.Add(o.SubjectLine);
                item.SubItems.Add(o.Status);
                item.SubItems.Add(o.CertusFileID);
                item.SubItems.Add(o.FileName);
                item.SubItems.Add(o.FileURL);

                queriedItemsListView.Items.Add(item);
                ++itemNum;
            }
        }
    }
}
