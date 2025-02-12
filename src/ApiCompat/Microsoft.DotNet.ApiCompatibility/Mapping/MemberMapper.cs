﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.CodeAnalysis;
using Microsoft.DotNet.ApiCompatibility.Rules;

namespace Microsoft.DotNet.ApiCompatibility.Mapping
{
    /// <summary>
    /// Object that represents a mapping between two <see cref="ISymbol"/> objects.
    /// </summary>
    public class MemberMapper : ElementMapper<ISymbol>, IMemberMapper
    {
        /// <inheritdoc />
        public ITypeMapper ContainingType { get; }

        /// <summary>
        /// Instantiates an object with the provided <see cref="ComparingSettings"/>.
        /// </summary>
        /// <param name="settings">The settings used to diff the elements in the mapper.</param>
        /// <param name="rightSetSize">The number of elements in the right set to compare.</param>
        public MemberMapper(IRuleRunner ruleRunner,
            IMapperSettings settings,
            int rightSetSize,
            ITypeMapper containingType)
            : base(ruleRunner, settings, rightSetSize)
        {
            ContainingType = containingType;
        }

        // If we got to this point it means that ContainingType.Left is not null.
        // Because of that we can only check ContainingType.Right.
        internal bool ShouldDiffElement(int rightIndex) =>
            ContainingType.Right.Length == 1 || ContainingType.Right[rightIndex] != null;
    }
}
