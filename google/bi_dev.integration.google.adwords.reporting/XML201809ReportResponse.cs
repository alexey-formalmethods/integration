using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace bi_dev.integration.google.adwords.reporting
{


    [XmlRoot(ElementName = "report-name")]
    public class Reportname
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "date-range")]
    public class Daterange
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
    }

    [XmlRoot(ElementName = "column")]
    public class Column
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "display")]
        public string Display { get; set; }
    }

    [XmlRoot(ElementName = "columns")]
    public class Columns
    {
        [XmlElement(ElementName = "column")]
        public List<Column> Column { get; set; }
    }
    
    
   
    [XmlRoot(ElementName = "table")]
    public class Table
    {
        [XmlElement(ElementName = "columns")]
        public Columns Columns { get; set; }
        [XmlElement(ElementName = "row")]
        public List<object> Row { get; set; }
    }

    [XmlRoot(ElementName = "report")]
    public class XML201809ReportResponse
    {
        [XmlElement(ElementName = "report-name")]
        public Reportname Reportname { get; set; }
        [XmlElement(ElementName = "date-range")]
        public Daterange Daterange { get; set; }
        [XmlElement(ElementName = "table")]
        public Table Table { get; set; }
    }


}
