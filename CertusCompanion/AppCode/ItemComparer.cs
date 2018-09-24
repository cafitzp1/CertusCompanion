using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    class ItemComparer : IEqualityComparer<WorkflowItem>
    {
        public int GetHashCode(WorkflowItem wi)
        {
            if (wi == null)
            {
                return 0;
            }
            return wi.DocumentWorkflowItemID.GetHashCode();
        }

        public bool Equals(WorkflowItem item1, WorkflowItem item2)
        {
            if (item1 == null && item2 == null)
                return true;
            else if (item1 == null | item2 == null)
                return false;
            // check for any changeable data
            else if (item1.DisplayColor != item2.DisplayColor)
                return false;
            else if (item1.Status != item2.Status)
                return false;
            else
                return true;
        }
    }
}
