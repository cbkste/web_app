
using System.Collections.Generic;

namespace web_app.Config
{
    public interface IConnectionHelper
   {                                                                         
        IEnumerable<T> Query<T>(string sql, object parameters);               
        IEnumerable<T> Query<T>(string sql);                                  
        void Execute(string sql, object parameters);                          
        int ExecuteAndGetNumberOfRowsAffected(string sql, object parameters); 
        void BeginTransaction();                                              
        void CommitTransaction();                                             
        void RollbackTransaction();                                           
    }                                    
}