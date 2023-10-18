// <copyright file="IAnimalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    using NBaseRepository.GuidPrimary;

    internal interface IAnimalRepository
        : IAddEntityAsync<GuidAnimal>
    {
    }
}
