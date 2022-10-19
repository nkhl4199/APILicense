using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILicence.Models
{
    public static class MongoDatabaseSettings
    {
        public static string ConnectionString { get; }

        public static string DatabaseName { get; set; } = null!;

        public static string BooksCollectionName { get; set; } = null!;
    }
}
