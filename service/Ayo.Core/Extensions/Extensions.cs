using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ayo.Core.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// 因为数据库不允许为空，则会自动赋默认值1751或1905
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNull(this DateTime @this)
        {
            return @this == null || @this.Year <= 1905;
        }

        /// <summary>
        /// String to MongoDb.Bson.ObjectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ObjectId ToObjectId(this string id)
        {
            return new ObjectId(id);
        }

        /// <summary>
        /// 判断是否objectId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsObjectId(this string id)
        {
            return ObjectId.TryParse(id, out _);
        }

        /// <summary>
        /// 批量转ObjectId
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<ObjectId> ToObjectIds(this IList<string> ids)
        {
            var listObjectIds = new List<ObjectId>();

            if (!ids.Any()) return listObjectIds;

            foreach (var item in ids)
            {
                ObjectId.TryParse(item, out ObjectId objectId);
                listObjectIds.Add(objectId);
            }

            return listObjectIds;
        }
    }
}