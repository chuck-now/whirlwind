﻿namespace BaseLib.Domain.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}