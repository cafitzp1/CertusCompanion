using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertusCompanion
{
    class CustomExceptions
    {
        // this page is for custom exceptions
    }

    [Serializable]
    class FileUnreadableException : Exception
    {
        public FileUnreadableException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class AppSaveLoadFailedException : Exception
    {
        public AppSaveLoadFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class AppDataLoadFailedException : Exception
    {
        public AppDataLoadFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemImportsLoadFailedException : Exception
    {
        public ItemImportsLoadFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemsCompletedReportsLoadFailedException : Exception
    {
        public ItemsCompletedReportsLoadFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class WorkflowItemDatabaseLoadFailedException : Exception
    {
        public WorkflowItemDatabaseLoadFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class AppSaveFailedException : Exception
    {
        public AppSaveFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class AppDataSaveFailedException : Exception
    {
        public AppDataSaveFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemImportsSaveFailedException : Exception
    {
        public ItemImportsSaveFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemsCompletedReportsSaveFailedException : Exception
    {
        public ItemsCompletedReportsSaveFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class WorkflowItemDatabaseSaveFailedException : Exception
    {
        public WorkflowItemDatabaseSaveFailedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemAlreadyAddedToDatabaseException : Exception
    {
        public ItemAlreadyAddedToDatabaseException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemImportAlreadyAddedException : Exception
    {
        public ItemImportAlreadyAddedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class ItemsCompletedReportAlreadyAddedException : Exception
    {
        public ItemsCompletedReportAlreadyAddedException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class CertificateImportNotCorrectFormatException : Exception
    {
        public CertificateImportNotCorrectFormatException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class CompanyImportNotCorrectFormatException : Exception
    {
        public CompanyImportNotCorrectFormatException(string message)
           : base(message)
        {
        }
    }

    [Serializable]
    class WorkflowItemImportNotCorrectFormatException : Exception
    {
        public WorkflowItemImportNotCorrectFormatException(string message)
           : base(message)
        {
        }
    }
}
