﻿using System.Threading.Tasks;

namespace BaseLib.Event.Bus.Handlers
{
    /// <summary>
    /// 定义一个处理 <see cref="IEventHandler{TEventData}"/> 类型事件的接口。
    /// </summary>
    /// <typeparam name="TEventData">要处理的事件类型</typeparam>
    public interface IAsyncEventHandler<in TEventData> : IEventHandler
    {
        /// <summary>
        /// 实现此方法处理事件
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        Task HandleEventAsync(TEventData eventData);
    }
}