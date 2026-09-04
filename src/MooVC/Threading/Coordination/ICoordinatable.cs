namespace MooVC.Threading.Coordination
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an object that can direct the context in which it is coordinated.
    /// </summary>
    /// <remarks>
    /// Returning the same key value from different instances causes those instances to share the same coordination boundary.
    /// </remarks>
    public interface ICoordinatable
    {
        /// <summary>
        /// Gets the key that serves as the context in which to coordinate operations on objects of the same type.
        /// </summary>
        /// <returns>The key used to coordinate operations on objects of the same type.</returns>
        string GetKey();
    }
}