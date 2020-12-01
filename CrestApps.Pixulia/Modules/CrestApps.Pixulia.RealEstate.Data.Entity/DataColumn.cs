using System.ComponentModel.DataAnnotations.Schema;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public class DataColumn : ColumnAttribute
    {
        public DataColumn(string columnName)
            : base(columnName)
        {
        }
    }
}

