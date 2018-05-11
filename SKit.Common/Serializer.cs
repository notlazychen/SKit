using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common
{
    public abstract class Serializer
    {
        /// <summary>
        /// 拆包
        /// </summary>
        /// <param name="buffer">接收缓冲区</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <param name="readlength">返回读取的头+身体的总长度</param>
        /// <returns>提取出数据实体包</returns>
        public abstract ArraySegment<byte> UnPack(byte[] buffer, int offset, int count, ref int readlength);

        ///// <summary>
        ///// 打包,将实体序列化后的数据打包成网络包
        ///// </summary>
        ///// <returns>打包完的数据包</returns>
        //public abstract ArraySegment<byte> Pack(byte[] data, byte[] buffer, int offset, int count);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <returns></returns>
        public abstract Object Deserialize(Type type, byte[] data, int offset, int count);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity">实体对象</param>
        ///// <param name="buffer">缓冲区</param>
        ///// <param name="count">可用长度</param>
        /// <returns>数据长度</returns>
        public abstract int Serialize(Object entity, byte[] buffer, int length);

        /// <summary>
        /// 标志实体类型的CMD
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">长度</param>
        /// <returns>Cmd</returns>
        public abstract string DataToCmd(byte[] data, int offset, int count);

        ///// <summary>
        ///// 标志实体类型的CMD
        ///// </summary>
        ///// <returns>Cmd</returns>
        //public abstract string EntityToCmd(Object entity);

        /// <summary>
        /// 对需要在初始化期间进行类型注册的可以重载此方法
        /// </summary>
        /// <param name="types"></param>
        public virtual void Register(Type type)
        {
        }
    }
}
