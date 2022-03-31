using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Entities
{
    public class Asset
    {
        #region Properties

        [Column(Order = 2)]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        [StringLength(6)]
        public string Name { get; set; }

        #endregion
    }
}