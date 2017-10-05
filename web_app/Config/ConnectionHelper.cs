// This is a somewhat silly class because IDbConnection is a nightmare to mock out.
using Dapper;
using System.Collections.Generic;
using System.Data;
using web_app.Config;

namespace web_app.Config {

public class ConnectionHelper : IConnectionHelper
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public ConnectionHelper(IDbConnection underlyingConnection)
        {
            _connection = underlyingConnection;
        }

        public IEnumerable<T> Query<T>(string sql, object parameters)
        {
            return _transaction != null
                ? _connection.Query<T>(sql, parameters, _transaction)
                : _connection.Query<T>(sql, parameters);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _transaction != null
                ? _connection.Query<T>(sql, null, _transaction)
                : _connection.Query<T>(sql);
        }

        public void Execute(string sql, object parameters)
        {
            if (_transaction != null)
            {
                _connection.Execute(sql, parameters, _transaction);
            }
            else
            {
                _connection.Execute(sql, parameters);
            }
        }

        public int ExecuteAndGetNumberOfRowsAffected(string sql, object parameters)
        {
            if (_transaction != null)
            {
               return _connection.Execute(sql, parameters, _transaction);
            }
            else
            {
               return _connection.Execute(sql, parameters);
            }
        }

        public void BeginTransaction()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}