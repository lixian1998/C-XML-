using System;
using System.Collections.Generic;
using System.Xml;

namespace XML
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test1();

            Console.ReadLine();
        }

        public static void Test1()
        {
            // 创建对象集合
            List<Student> list = new List<Student>();

            // 【1】创建XML文档操作对象
            XmlDocument objDoc = new XmlDocument();
            // 【2】加载XML文件到文档对象中
            objDoc.Load("Student.xml");
            // 【3】获取XML文档根目录
            XmlNode rootNode = objDoc.DocumentElement;
            // 【4】遍历根节点（根节点包含所有节点）
            foreach (XmlNode stuNode in rootNode.ChildNodes)
            {
                if (stuNode.Name == "Student")
                {
                    Student objStu = new Student();
                    // 【5】遍历子节点
                    foreach (XmlNode subNode in stuNode)
                    {
                        // 根据子节点的名称封装到对象的属性
                        switch (subNode.Name)
                        {
                            case "StuName":
                                objStu.StuName = subNode.InnerText; // 获取节点名称对应的节点值
                                break;
                            case "StuAge":
                                objStu.StuAge = Convert.ToInt32(subNode.InnerText);
                                break;
                            case "Gender":
                                objStu.Gender = Convert.ToInt32(subNode.InnerText);
                                break;
                            case "ClassName":
                                objStu.ClassName = subNode.InnerText;
                                break;
                            default:
                                break;
                        }
                    }
                    list.Add(objStu);
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.StuName + "\t" + item.Gender + "\t" + item.StuAge + "\t" + item.ClassName);
            }
        }
    }
}
