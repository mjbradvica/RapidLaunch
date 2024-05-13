// <copyright file="IAirplaneRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
