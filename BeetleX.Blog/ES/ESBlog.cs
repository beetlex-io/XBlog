using BeetleX.Elasticsearch.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeetleX.Blog.ES
{
    [TableType("Blog")]
    public class ESBlog
    {
        [ID]
        [Column(Type = ColumnType._keyword)]
        public string ID { get; set; }

        [Column(Type = ColumnType._text,
            Analyzer = Elasticsearch.AnalyzerType.ik_max_word,
            SearchAnalyzer = Elasticsearch.AnalyzerType.ik_smart)]
        public string Title { get; set; }

        [Column(Type = ColumnType._boolean)]
        public bool Top { get; set; }

        [Column(Type = ColumnType._text,
           Analyzer = Elasticsearch.AnalyzerType.ik_max_word,
           SearchAnalyzer = Elasticsearch.AnalyzerType.ik_smart)]
        public string Content { get; set; }

        [Column(Type = ColumnType._text, Index = false)]
        public string Summary { get; set; }

        [Column(Type = ColumnType._text, FieldData = true, Analyzer = Elasticsearch.AnalyzerType.whitespace,
           SearchAnalyzer = Elasticsearch.AnalyzerType.whitespace)]
        public string Category { get; set; }

        [Column(Type = ColumnType._long)]
        public long CategoryID { get; set; }

        [Column(Type = ColumnType._text,
           Analyzer = Elasticsearch.AnalyzerType.whitespace,
           SearchAnalyzer = Elasticsearch.AnalyzerType.whitespace, FieldData = true)]
        public string Tags { get; set; }

        [Column(Type = ColumnType._text, Index = false)]
        public string SourceUrl { get; set; }

        [Column(Type = ColumnType._date)]
        public DateTime CreateTime { set; get; }
    }
}
