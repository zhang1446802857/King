﻿using SqlSugar;

namespace King.WebApi.Model.Models
{
    [SugarTable("Test")]
    public class TestModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "Id")]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}