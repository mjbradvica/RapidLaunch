// <copyright file="IAirplaneRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using RapidLaunch.GuidPrimary;

namespace RapidLaunch.EF.Samples.Airplanes
{
    /// <summary>
    /// Interface for airplane persistence.
    /// </summary>
    public interface IAirplaneRepository :
        IAddRootAsync<Airplane>,
        IGetAllEntitiesAsync<Airplane>
    {
    }
}
