using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices.JsonSchemas
{
    public class TestSchema
    {
        public string Schema { get; } = 
            @"{
                'description': 'a test',
                'type': 'object',
                'properties':
                    {
                        'name': {'type':'string'},
                        'phoneNumber': { 'type': 'array',
      'items': {'type':'string'}
    }
  }
}";
    }
}
