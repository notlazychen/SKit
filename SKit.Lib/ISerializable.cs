using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Base
{
    public interface ISerializable
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <returns></returns>
        Object Deserialize(Type type, byte[] data, int offset, int count);
   
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">实体对象</param>
        ///// <param name="buffer">缓冲区</param>
        ///// <param name="offset">可用偏移</param>
        ///// <param name="count">可用长度</param>
        /// <returns>数据</returns>
        byte[] Serialize<T>(T entity);

        /// <summary>
        /// 标志实体类型的CMD
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <returns>Cmd</returns>
        string DataToCmd(byte[] data, int offset, int count);

        /// <summary>
        /// 标志实体类型的CMD
        /// </summary>
        /// <returns>Cmd</returns>
        string EntityToCmd(Object entity);
    }
}
