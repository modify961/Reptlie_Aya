using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;

namespace Base.Common
{
    public static class EntityHelp
    {
        /// <summary>
        /// 将DataRow  转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T toEntitys<T>(DataRow dr, T entity)
        {
            T t = entity;
            PropertyInfo[] propertyInfo = t.GetType().GetProperties();
            foreach (PropertyInfo property in propertyInfo)
            {
                if (dr.Table.Columns.Contains(property.Name))
                {
                    if (!property.CanWrite) continue;
                    object value = dr[property.Name];
                    if (value != DBNull.Value)
                        property.SetValue(t, value, null);
                }
            }
            return t;
        }
        /// <summary>
        /// where T : new()泛型约束：指定方法内部可以调用泛型的无参构造函数创建对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> toEntity<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            foreach (DataRow dr in dataTable.Rows)
            {
                T t = new T();
                PropertyInfo[] propertyInfo = t.GetType().GetProperties();
                foreach (PropertyInfo property in propertyInfo)
                {
                    if (dataTable.Columns.Contains(property.Name))
                    {
                        if (!property.CanWrite) continue;
                        object value = dr[property.Name];
                        if (value != DBNull.Value)
                            property.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }
        /// <summary>
        /// 将泛型的值转换为dataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable toDataTable<T>(List<T> list)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in propertyInfo)
            {
                Type t = getType(prop.PropertyType);
                dataTable.Columns.Add(prop.Name, t);
            }
            foreach (T item in list)
            {
                var values = new object[propertyInfo.Length];
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    values[i] = propertyInfo[i].GetValue(item, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        /// <summary>
        /// 将泛型的值转换为dataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable toDataTable<T>(T t)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in propertyInfo)
            {
                Type type = getType(prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            var values = new object[propertyInfo.Length];
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                values[i] = propertyInfo[i].GetValue(t, null);
            }
            dataTable.Rows.Add(values);
            return dataTable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Type getType(Type t)
        {
            if (isNullable(t))
            {
                if (!t.IsValueType)
                    return t;
                else
                    return Nullable.GetUnderlyingType(t);
            }
            else
                return t;
        }
        /// <summary>
        /// 判断数据键值是否允许为空
        /// IsValueType：判断是否为值类型
        /// IsGenericType：判断是否为泛型类型
        /// GetGenericTypeDefinition：
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool isNullable(Type t)
        {
            return t != null && !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
