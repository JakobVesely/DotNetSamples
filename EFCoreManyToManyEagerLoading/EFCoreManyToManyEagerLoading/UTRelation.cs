using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreManyToManyEagerLoading
{
    class UTRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
