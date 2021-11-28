namespace NBaseRepository.ADO
{
    using System;
    using System.Data.SqlClient;

    public static class SqlDataReaderExtensions
    {
        public static Guid ToGuid(this SqlDataReader reader, int position)
        {
            return Guid.Parse(reader.ToString(position));
        }

        public static string ToString(this SqlDataReader reader, int position)
        {
            return reader[position].ToString();
        }

        public static int ToInt(this SqlDataReader reader, int position)
        {
            return int.Parse(reader.ToString(position));
        }
    }
}
