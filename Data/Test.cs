using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Test
    {
        public int Id { get; set; }

        [Column()]
        public string Name { get; set; }

        [Column(TypeName = "jsonb")]
        public string Data { get; set; }
    }
}
