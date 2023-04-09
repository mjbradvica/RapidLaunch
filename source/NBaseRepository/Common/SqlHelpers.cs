namespace NBaseRepository.Common
{
    public static class SqlHelpers
    {
        public static string InnerJoin<TPrimary, TDependent>()
            where TDependent : class
            where TPrimary : class
        {
            return $"INNER JOIN dbo.{typeof(TDependent).Name} ON dbo.{typeof(TDependent).Name}.Id = dbo.{typeof(TPrimary).Name}.{typeof(TDependent).Name}Id";
        }
    }
}
