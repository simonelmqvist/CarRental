using System.Collections.Generic;
using System.Linq;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Models;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CarRental.Core.Classes.Concrete
{
    class DbReceives : IDbReceives<ReceivesDbModel>
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
            _tableName = "CrRents";
        }

        public void Insert(ReceivesDbModel model)
        {
            CreateTabelIfNone();

            _db.Insert(model);
        }

        public void Delete(ReceivesDbModel model)
        {
            _db.Delete(model);
        }

        public IEnumerable<ReceivesDbModel> GetAll()
        {
            CreateTabelIfNone();

            var query = "Select * From " + _tableName;
            return _db.Query<ReceivesDbModel>(query);
        }

        public ReceivesDbModel GetById(int id)
        {
            CreateTabelIfNone();

            var query = "Select From " + _tableName + " Where BookingId = " + id;
            return _db.Query<ReceivesDbModel>(query).FirstOrDefault();
        }

        public void CreateTabelIfNone()
        {
            if (!_dbSchemaHelper.TableExist(_tableName))
                _dbSchemaHelper.CreateTable<ReceivesDbModel>(false);
        }
    }
}