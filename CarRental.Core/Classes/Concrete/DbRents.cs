using System.Collections.Generic;
using System.Linq;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Models;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CarRental.Core.Classes.Concrete
{
    public class DbRents : IDbRents<RentsDbModel>
    {
        private readonly DatabaseSchemaHelper _dbSchemaHelper;
        private readonly Database _db;
        private readonly string _tableName;

        public DbRents()
        {
            var applicationContext = ApplicationContext.Current;
            var ctx = applicationContext.DatabaseContext;
            _dbSchemaHelper = new DatabaseSchemaHelper(ctx.Database, applicationContext.ProfilingLogger.Logger, ctx.SqlSyntax);
            _db = ApplicationContext.Current.DatabaseContext.Database;
            _tableName = "CrRents";
        }

        public void Insert(RentsDbModel model)
        {
            CreateTabelIfNone();

            _db.Insert(model);
        }

        public void Delete(RentsDbModel model)
        {
            _db.Delete(model);
        }

        public IEnumerable<RentsDbModel> GetAll()
        {
            CreateTabelIfNone();

            var query = "Select * From " + _tableName;
            return _db.Query<RentsDbModel>(query);
        }

        public RentsDbModel GetById(int id)
        {
            CreateTabelIfNone();

            var query = "Select From " + _tableName + " Where BookingId = " + id;
            return _db.Query<RentsDbModel>(query).FirstOrDefault();
        }

        public void CreateTabelIfNone()
        {
            if (!_dbSchemaHelper.TableExist(_tableName))
                _dbSchemaHelper.CreateTable<RentsDbModel>(false);
        }
    }
}