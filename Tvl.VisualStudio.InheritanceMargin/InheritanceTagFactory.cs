﻿namespace Tvl.VisualStudio.InheritanceMargin
{
    using System.Collections.Generic;
    using System.Linq;

    internal class InheritanceTagFactory : IInheritanceTagFactory
    {
        public IInheritanceTag CreateTag(InheritanceGlyph glyph, string displayName, IEnumerable<IInheritanceTarget> targets)
        {
            return new InheritanceTag(glyph, displayName, targets.ToList());
        }
    }
}
