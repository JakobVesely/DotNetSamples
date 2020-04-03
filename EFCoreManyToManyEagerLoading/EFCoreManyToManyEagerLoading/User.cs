using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreManyToManyEagerLoading
{
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<UTRelation> UTRelations { get; set; } = new List<UTRelation>();
    }
}
