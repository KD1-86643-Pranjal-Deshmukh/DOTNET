using System.Data;

namespace AttributesLib
{
    public class DataTable : Attribute {
        public string name { get; set; }
    }
    public class DataColumn : Attribute {
        public string name { get; set; }
    }
    public class KeyColumn : Attribute {
    }
    public class  UnMapped : Attribute  {
    }
}
