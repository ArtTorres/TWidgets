﻿namespace TWidgets.Core.Interactive
{
    /// <summary>
    /// Specifies constants that defines the behavior after a validation.
    /// </summary>
    public enum ErrorAction
    {
        /// <summary>
        /// Repeat the input.
        /// </summary>
        Repeat,

        /// <summary>
        /// Continue with the next input or finish.
        /// </summary>
        Continue,

        /// <summary>
        /// Ignore the validation results.
        /// </summary>
        Ignore
    }
}
