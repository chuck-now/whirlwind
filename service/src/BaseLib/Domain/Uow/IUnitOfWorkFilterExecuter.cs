﻿namespace BaseLib.Domain.Uow
{
    /// <summary>
    /// IUnitOfWorkFilterExecuter
    /// </summary>
    public interface IUnitOfWorkFilterExecuter
    {
        void ApplyDisableFilter(IUnitOfWork unitOfWork, string filterName);

        void ApplyEnableFilter(IUnitOfWork unitOfWork, string filterName);

        void ApplyFilterParameterValue(IUnitOfWork unitOfWork, string filterName, string parameterName, object value);
    }
}