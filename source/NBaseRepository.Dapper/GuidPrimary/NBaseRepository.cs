namespace NBaseRepository.Dapper.GuidPrimary
{
    using System;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using NBaseRepository.GuidPrimary;

    public abstract class NBaseRepository<TFirst, TEntity> : NBaseCoreRepository<TFirst, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TEntity> : NBaseCoreRepository<TFirst, TSecond, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }
}
