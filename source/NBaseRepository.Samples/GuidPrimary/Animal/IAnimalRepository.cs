// <copyright file="IAnimalRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    internal interface IAnimalRepository
        : IAddEntityAsync<GuidAnimal>
    {
    }
}
