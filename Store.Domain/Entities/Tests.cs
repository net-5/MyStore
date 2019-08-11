using System;
using System.Collections.Generic;

namespace MyStore.Domain.Entities
{
    public class Tests
    {
        public Tests()
        {
            Scores = new HashSet<Scores>();
        }

        public string Testid { get; set; }

        public virtual ICollection<Scores> Scores { get; set; }
    }
}
