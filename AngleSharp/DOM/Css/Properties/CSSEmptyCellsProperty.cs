﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/empty-cells
    /// </summary>
    sealed class CSSEmptyCellsProperty : CSSProperty
    {
        #region Fields

        static readonly Dictionary<String, CellMode> modes = new Dictionary<String, CellMode>(StringComparer.OrdinalIgnoreCase);
        CellMode _mode;

        #endregion

        #region ctor

        static CSSEmptyCellsProperty()
        {
            modes.Add("show", CellMode.Show);
            modes.Add("hide", CellMode.Hide);
        }

        public CSSEmptyCellsProperty()
            : base(PropertyNames.EmptyCells)
        {
            _mode = CellMode.Show;
            _inherited = true;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            CellMode mode;

            if (value is CSSIdentifierValue && modes.TryGetValue(((CSSIdentifierValue)value).Value, out mode))
                _mode = mode;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion

        #region Modes

        enum CellMode
        {
            /// <summary>
            /// Is a keyword indicating that borders and backgrounds
            /// should be drawn like in a normal cells.
            /// </summary>
            Show,
            /// <summary>
            /// Is a keyword indicating that no border or backgrounds
            /// should be drawn.
            /// </summary>
            Hide
        }

        #endregion
    }
}
