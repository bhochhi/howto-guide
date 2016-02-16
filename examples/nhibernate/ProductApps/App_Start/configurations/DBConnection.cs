using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApps.App_Start.configurations
{

    public interface IDbConnection
    {
        ISessionFactory CreateSessionFactory();
    }

    public class DBConnection : IDbConnection 
    {
        private ISessionFactory _isessionFactory;    

        public  ISessionFactory CreateSessionFactory()
        {
            if(_isessionFactory == null)
            {
                _isessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString("Server=localhost\\SQLEXPRESS; Database=CMS; Integrated Security=SSPI;").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<mappings.ProductMap>())
                .BuildSessionFactory();
            }
            return _isessionFactory;            
        }

    }
}