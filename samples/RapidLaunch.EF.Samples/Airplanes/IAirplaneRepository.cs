// <copyright file="IAirplaneRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using RapidLaunch.GuidPrimary;

namespace RapidLaunch.EF.Samples.Airplanes
{
    /// <summary>
    /// Interface for airplane persistence.
    /// </summary>
    public interface IAirplaneRepository :
        IAddEntityAsync<Airplane>,
        IGetAllEntitiesAsync<Airplane>
    {
    }
}
