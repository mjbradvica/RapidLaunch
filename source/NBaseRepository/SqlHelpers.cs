namespace NBaseRepository
{
    using System;

    public static class SqlHelpers
    {
        public static string InnerJoin<TPrimary, TDependent>()
            where TDependent : class
            where TPrimary : class
        {
            return $"INNER JOIN dbo.{typeof(TPrimary).Name} ON dbo.{typeof(TPrimary).Name}.Id = do.{typeof(TDependent).Name}.{typeof(TPrimary).Name}Id";
        }
    }
}
