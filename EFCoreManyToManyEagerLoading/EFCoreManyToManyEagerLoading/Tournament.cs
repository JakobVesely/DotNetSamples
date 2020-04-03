using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreManyToManyEagerLoading
{
    class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public IList<UTRelation> UTRelations { get; set; } = new List<UTRelation>();
    }
}