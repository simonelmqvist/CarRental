using System.Collections.Generic;
using System.Linq;
using CarRental.Core.Classes.Abstract;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CarRental.Core.Classes.Concrete
{
    public class DbRents : IDbRents<RentDbModel>
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

        public void Insert(RentDbModel model)
        {
            CreateTabelIfNone();
            _db.Insert(model);
        }

        public void Delete(RentDbModel model)
        {
            _db.Delete(model);
        }

        public IEnumerable<RentDbModel> GetAll()
        {
            CreateTabelIfNone();

            var query = "Select * From " + _tableName;
            return _db.Query<RentDbModel>(query);
        }

        public RentDbModel GetById(int id)
        {
            CreateTabelIfNone();

            var query = "Select From " + _tableName + " Where BookingId = " + id;
            return _db.Query<RentDbModel>(query).FirstOrDefault();
        }

        public void CreateTabelIfNone()
        {
            if (!_dbSchemaHelper.TableExist(_tableName))
                _dbSchemaHelper.CreateTable<RentDbModel>(false);
        }
    }
}