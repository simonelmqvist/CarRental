using System.Collections.Generic;
using System.Linq;
using CarRental.Core.Classes.Abstract;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CarRental.Core.Classes.Concrete
{
    public class DbReceives : IDbReceives<ReceiveDbModel>
    {
        private readonly DatabaseSchemaHelper _dbSchemaHelper;
        private readonly Database _db;
        private readonly string _tableName;

        public DbReceives()
        {
            var applicationContext = ApplicationContext.Current;
            var ctx = applicationContext.DatabaseContext;
            _dbSchemaHelper = new DatabaseSchemaHelper(ctx.Database, applicationContext.ProfilingLogger.Logger, ctx.SqlSyntax);
            _db = ApplicationContext.Current.DatabaseContext.Database;
            _tableName = "CrReceives";
        }

        public void Insert(ReceiveDbModel model)
        {
            CreateTabelIfNone();
            _db.Insert(model);
        }

        public void Delete(ReceiveDbModel model)
        {
            _db.Delete(model);
        }

        public IReceiveDbModel GetByBookingId(int id)
        {
            CreateTabelIfNone();

            var query = "Select * From " + _tableName + " Where BookingId = " + id;
            return _db.Query<ReceiveDbModel>(query).FirstOrDefault();
        }

        public void CreateTabelIfNone()
        {
            if (!_dbSchemaHelper.TableExist(_tableName))
                _dbSchemaHelper.CreateTable<ReceiveDbModel>(false);
        }
    }
}