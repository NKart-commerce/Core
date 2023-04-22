namespace NKart.Web.Validation
{
    using NKart.Core.Validation;

    /// <summary>
    /// Defines a ValidationHelper.
    /// </summary>
    public interface IValidationHelper
    {
        /// <summary>
        /// Gets the <see cref="IBankingValidationHelper"/>.
        /// </summary>
        IBankingValidationHelper Banking { get; }

        /// <summary>
        /// Gets the <see cref="IEmailValidationHelper"/>.
        /// </summary>
        IEmailValidationHelper Email { get; }
    }
}