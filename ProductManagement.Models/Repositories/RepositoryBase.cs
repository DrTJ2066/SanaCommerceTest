using ProductManagement.Models.DAL;
using ProductManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models.Repositories
{
    public class RepositoryBase
    {
        #region Fields

        protected IContext Context;

        #endregion

        #region Constructors

        public RepositoryBase(IContext context)
        {
            Context = context;
        }

        #endregion

        #region Properties

        public bool IsDatabaseContext => Context is DatabaseContext;

        public bool IsMemoryContext => Context is MemoryContext;

        #endregion

        #region Methods

        public void ToggleContext()
        {
            var contextType = IsDatabaseContext ? ContextTypes.Memory : ContextTypes.Database;
            switch (contextType)
            {
                case ContextTypes.Database:
                    if (!IsDatabaseContext)
                    {
                        Context = new DatabaseContext();
                    }
                    break;


                case ContextTypes.Memory:
                    if (!IsMemoryContext)
                    {
                        Context = new MemoryContext();
                    }
                    break;
            }
        }

        public ContextTypes GetContextType()
        {
            return Context is DatabaseContext ? ContextTypes.Database : ContextTypes.Memory;
        }

        #endregion
    }
}