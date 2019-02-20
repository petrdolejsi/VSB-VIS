using System;
using System.Collections.ObjectModel;
using System.Xml;
using Library.Models;

namespace Library.Mapping
{
    public class ToDoMapper
    {
        public Collection<ToDo> GetAll()
        {
            var todos = new Collection<ToDo>();

            try
            {
                const string path = "../../../Library/todo.xml";

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                XmlNodeList items = xDoc.GetElementsByTagName("item");
                foreach (XmlNode xItem in items)
                {
                    var item = new ToDo();
                    item.Title = xItem.SelectSingleNode("title")?.InnerText;
                    item.Text = xItem.SelectSingleNode("text")?.InnerText;

                    todos.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return todos;
        }
    }
}
