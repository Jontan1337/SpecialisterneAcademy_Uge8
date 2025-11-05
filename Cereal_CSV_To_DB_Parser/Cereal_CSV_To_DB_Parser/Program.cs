namespace Cereal_CSV_To_DB_Parser
{
    using MySqlConnector;
    using System.Threading.Tasks;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Connection string to the database.
            // AllowLoadLocalInfile=True is required to be able to load data into the database.
            string connectionString = "Server=localhost;User ID=root;Password=;Database=Cereal;AllowLoadLocalInfile=True;SslMode=None";

            await using var conn = new MySqlConnection(connectionString);

            await conn.OpenAsync();

            var bulkLoader = new MySqlBulkLoader(conn)
            {
                TableName = "Products",
                FileName = @"C:\Users\SPAC-30\Desktop\Cereal.csv",
                Local = true,                                       // Tell the client to allow file reading.
                CharacterSet = "utf8mb4",
                FieldTerminator = ";",                              // The column seperator.
                FieldQuotationCharacter = '"',                      // Determines some values might be wrapped in ".
                EscapeCharacter = '\\',                             // Used for escaping characters that are inside quotation.
                LineTerminator = "\n",                              // Newline/Line break for rows.
                NumberOfLinesToSkip = 2,                            // How many lines to skip from the top.
            };

            // Columns with @ tells the bulkloader to wait with inserting fields from the file before we transform them with expressions below.
            bulkLoader.Columns.AddRange(new[]
            {
                "Name", "Manufacturer", "@type", "Calories", "Protein", "Fat", "Sodium",
                "@fiber", "@carbo", "Sugars", "Potass", "Vitamins", "Shelf", "@weight", "@cups", "@rating"
            });

            // "Type" is a keyword/reserved word in MySQL/MariaDB according to https://dev.mysql.com/doc/refman/5.7/en/keywords.html#keywords-5-7-detailed-T, so we use backticks (``) to make sure the parser doesn't get confused.
            bulkLoader.Expressions.Add("`Type` = IF(UPPER(@type)='C', 'COLD', IF(UPPER(@type)='H', 'HOT', NULL))");
            bulkLoader.Expressions.Add("Fiber = NULLIF(REPLACE(@fiber, ',', '.'), '')");
            bulkLoader.Expressions.Add("Carbo = NULLIF(REPLACE(@carbo, ',', '.'), '')");
            bulkLoader.Expressions.Add("Weight = NULLIF(REPLACE(@weight, ',', '.'), '')");
            bulkLoader.Expressions.Add("Cups = NULLIF(REPLACE(@cups, ',', '.'), '')");
            bulkLoader.Expressions.Add("Rating = NULLIF(REPLACE(@rating, ',', '.'), '')");

            int rows = await bulkLoader.LoadAsync();
            Console.WriteLine($"Loaded {rows}");
        }
    }
}
