using SqlSugar;
namespace King.WebApi.Model.Models
{
    /// <summary>
    /// 日志记录表
    ///</summary>
    [SugarTable("K_Logging")]
    public class LoggingModel
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 日志来源 
        ///</summary>
        [SugarColumn(ColumnName = "Source")]
        public string Source { get; set; }
        /// <summary>
        /// 操作人 
        ///</summary>
        [SugarColumn(ColumnName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
        [SugarColumn(ColumnName = "CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 日志等级:0-error，1-info,2-debug 
        ///</summary>
        [SugarColumn(ColumnName = "Level")]
        public int Level { get; set; }
        /// <summary>
        /// 日志内容 
        ///</summary>
        [SugarColumn(ColumnName = "Content")]
        public string Content { get; set; }
    }
}
