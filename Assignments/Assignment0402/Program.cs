using System.Reflection;
using AttributesLib;
namespace ORM
{
    internal class UsingAttributeCreatingQuery
    {
        public static string getMySQLDatatype(string s) {
            if ("System.String" == s) {
                return "VARCHAR(255)";
            }
            if ("System.Double" == s) {
                return "DOUBLE";
            }
            return "INT";
        }
        public static void Main(String[] cs)
        {
            string path = "C:\\Users\\Ganesh\\Desktop\\dotnet\\AssignmentSolutions\\EntityLib\\bin\\Debug\\net6.0\\EntityLib.dll";
            Assembly assembly = Assembly.LoadFrom(path);
            string query = "";
            Type[] types = assembly.GetTypes();
            foreach (Type type in types) {
                if (!type.FullName.Contains("Attribute")) {
                    string subQuery = "CREATE TABLE ";
                    Attribute[] attributes = type.GetCustomAttributes().ToArray();
                    foreach (Attribute attribute in attributes) {
                        if (attribute is DataTable) { 
                            DataTable dataTable = (DataTable)attribute;
                            if (dataTable.name != null)
                            {
                                subQuery = subQuery + dataTable.name + "(";
                            }
                            else {
                                subQuery = subQuery + type.Name + "(";
                            }
                            PropertyInfo[] properties = type.GetProperties();
                            string endPrimaryKey = "";
                            foreach (PropertyInfo property in properties) {
                                Attribute[] attrs = property.GetCustomAttributes().ToArray();
                                foreach (Attribute attr in attrs) {
                                    if (attr is KeyColumn) {
                                        endPrimaryKey = property.Name + " " + getMySQLDatatype(property.PropertyType.ToString()) + " PRIMARY KEY)";
                                    }
                                    if (attr is DataColumn) { 
                                        DataColumn column = (DataColumn)attr;
                                        string colName = "";
                                        if (column.name == null) {
                                            colName = property.Name + " " + getMySQLDatatype(property.PropertyType.ToString());
                                        }
                                        else {
                                            colName = column.name + " " + getMySQLDatatype(property.PropertyType.ToString());
                                        }
                                        subQuery = subQuery + colName + ", ";
                                    }
                                }
                            }
                            subQuery = subQuery + endPrimaryKey + ";";
                        }
                    }
                    query = query + subQuery;
                }
            }
            string hibfile = "C:\\Users\\Ganesh\\Desktop\\dotnet\\Classwork\\TableSchema.sql";
            FileStream fileStream = null;
            if (File.Exists(hibfile))
            {
                fileStream = new FileStream(hibfile, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fileStream = new FileStream(hibfile, FileMode.OpenOrCreate, FileAccess.Write);
            }
            StreamWriter streamWriter = new StreamWriter(fileStream);
            Console.WriteLine("success...!");
            streamWriter.Write(query);
            streamWriter.Close();
            fileStream.Close();
        }
    }
}