using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertusCompanion
{
    class CustomControls
    {
        // this page is for overriding controls within the project
    }

    class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new CompanionColors()) { }
    }

    class CompanionColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(46, 200, 150); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(46, 200, 150); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(102, 210, 160); }
        }
    }

    class BorderPanel : Panel
    {
        Color colorBorder = Color.FromName("MenuHighlight");

        public BorderPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(colorBorder), 2), e.ClipRectangle);
        }
    }

    class PlaceHolderTextBox : TextBox
    {

        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text;
            set => base.Text = value;
        }

        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void removePlaceHolder()
        {

            if (isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public PlaceHolderTextBox()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        private void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }

    class ListViewNF : ListView
    {
        //private bool checkFromDoubleClick = false;

        public ListViewNF()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out Windows messages before they get to the form's WndProc
            //    this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        //// HUGE PROBELM for program. causes any message box to crash everything.
        //protected override void OnNotifyMessage(Message m)
        //{
        //    //Filter out the WM_ERASEBKGND message
        //    if (m.Msg != 0x14)
        //    {
        //        base.OnNotifyMessage(m);
        //    }
        //}

        // prevent double click from checking 
        //protected override void OnItemCheck(ItemCheckEventArgs ice)
        //{
        //    if (this.checkFromDoubleClick)
        //    {
        //        ice.NewValue = ice.CurrentValue;
        //        this.checkFromDoubleClick = false;
        //    }
        //    else
        //        base.OnItemCheck(ice);
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    // Is this a double-click?
        //    if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
        //    {
        //        this.checkFromDoubleClick = true;
        //    }
        //    base.OnMouseDown(e);
        //}

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    this.checkFromDoubleClick = false;
        //    base.OnKeyDown(e);
        //}
    }

    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }

    class CustomPanel : Panel
    {
        Color colorBorder = Color.FromName("ButtonHighlight");

        public CustomPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(colorBorder), 8), e.ClipRectangle);
        }
    }
}
