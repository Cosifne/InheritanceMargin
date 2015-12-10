﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Microsoft Reciprocal License (MS-RL). See LICENSE in the project root for license information.

namespace Tvl.VisualStudio.InheritanceMargin
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Formatting;

    using CommandBinding = System.Windows.Input.CommandBinding;

    internal class InheritanceGlyphFactory : IGlyphFactory
    {
        private readonly InheritanceGlyphFactoryProvider _provider;
        private readonly IWpfTextView _view;
        private readonly IWpfTextViewMargin _margin;

        public InheritanceGlyphFactory(InheritanceGlyphFactoryProvider provider, IWpfTextView view, IWpfTextViewMargin margin)
        {
            this._provider = provider;
            this._view = view;
            this._margin = margin;
        }

        public UIElement GenerateGlyph(IWpfTextViewLine line, IGlyphTag tag)
        {
            InheritanceTag inheritanceTag = tag as InheritanceTag;
            if (inheritanceTag == null)
                return null;

            string imageName;
            switch (inheritanceTag.Glyph)
            {
            case InheritanceGlyph.HasImplementations:
                imageName = "has-implementations";
                break;

            case InheritanceGlyph.Implements:
                imageName = "implements";
                break;

            case InheritanceGlyph.ImplementsAndHasImplementations:
                imageName = "override-is-overridden-combined";
                break;

            case InheritanceGlyph.ImplementsAndOverridden:
                imageName = "override-is-overridden-combined";
                break;

            case InheritanceGlyph.Overridden:
                imageName = "is-overridden";
                break;

            case InheritanceGlyph.Overrides:
                imageName = "overrides";
                break;

            case InheritanceGlyph.OverridesAndOverridden:
                imageName = "override-is-overridden-combined";
                break;

            default:
                return null;
            }

            BitmapSource source = new BitmapImage(new Uri("pack://application:,,,/Tvl.VisualStudio.InheritanceMargin;component/Resources/" + imageName + ".png"));
            Image image = new Image()
                {
                    Source = source
                };
            image.CommandBindings.Add(new CommandBinding(InheritanceMarginPackage.InheritanceTargetsList, inheritanceTag.HandleExecutedInheritanceTargetsList, inheritanceTag.HandleCanExecuteInheritanceTargetsList));

            inheritanceTag.MarginGlyph = image;

            return image;
        }
    }
}
