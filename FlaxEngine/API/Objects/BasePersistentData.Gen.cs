// Copyright (c) 2012-2019 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Class for management of data stored in a file.
    /// </summary>
    public abstract partial class BasePersistentData : Object
    {
        /// <summary>
        /// Clears file content.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual void Clear()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Clear(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Saves all pending changes to the persistant data file.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual void Flush()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Flush(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Gets value form persistent data file.
        /// </summary>
        /// <param name="key">Key to find in persistent data file.</param>
        /// <returns>null if value was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual object Get(string key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Get(unmanagedPtr, key);
#endif
        }

        /// <summary>
        /// Gets value form persistent data file.
        /// </summary>
        /// <param name="key">Key to find in persistent data file.</param>
        /// <typeparam name="T">Data expected value type</typeparam>
        /// <returns>default(T) if value was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual T Get<T>(string key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return (T)Internal_GetWithType(unmanagedPtr, key, typeof(T));
#endif
        }

        /// <summary>
        /// Gets value form persistent data file. Creates file and value if not exists.
        /// </summary>
        /// <param name="key">Key to find in persistent data file.</param>
        /// <returns>null if value was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual object GetOrCreate(string key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Get(unmanagedPtr, key);
#endif
        }

        /// <summary>
        /// Gets value form persistent data file. Creates file and value if not exists.
        /// </summary>
        /// <param name="key">Key to find in persistent data file.</param>
        /// <typeparam name="T">Data expected value type</typeparam>
        /// <returns>default(T) if value was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public virtual T GetOrCreate<T>(string key)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return (T)Internal_GetWithType(unmanagedPtr, key, typeof(T));
#endif
        }

        /// <summary>
        /// Gets persistant data from desired file.
        /// </summary>
        /// <param name="fileName">File to get persistant data from.</param>
        /// <param name="createNew">If file was not found, should method create new file.</param>
        /// <returns>null if file was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static BasePersistentData File(string fileName, bool createNew = false)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_File(fileName, createNew);
#endif
        }

        /// <summary>
        /// Gets persistant data from desired file by its config mapped name.
        /// </summary>
        /// <param name="fileName">File to get persistant data from by name from internal dictionary. Has to be mapped in config file.</param>
        /// <param name="createNew">If file was not found, should method create new file.</param>
        /// <returns>null if file was not found.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static BasePersistentData FileByName(string fileName, bool createNew = false)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FileByName(fileName, createNew);
#endif
        }

        /// <summary>
        /// Creates new file for persistant data.
        /// </summary>
        /// <param name="fileName">File name to create file at.</param>
        /// <returns>Newly created file.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static BasePersistentData FileCreate(string fileName)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FileCreate(fileName);
#endif
        }

        /// <summary>
        /// Creates new file for persistant data.
        /// </summary>
        /// <param name="fileName">File name to create file at.</param>
        /// <returns>Newly created file.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static BasePersistentData FileCreateByName(string fileName)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FileCreateByName(fileName);
#endif
        }

        /// <summary>
        /// Creates new file for persistant data.
        /// </summary>
        /// <param name="fileName">File name to create file at.</param>
        /// <param name="fileConfigName">Config name that this file will be mapped to.</param>
        /// <returns>Newly created file.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static BasePersistentData FileCreateByName(string fileName, string fileConfigName)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FileCreateByName_Param(fileName, fileConfigName);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Clear(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Flush(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern object Internal_Get(IntPtr obj, string key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern object Internal_GetWithType(IntPtr obj, string key, Type type);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern BasePersistentData Internal_File(string fileName, bool createNew);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern BasePersistentData Internal_FileByName(string fileName, bool createNew);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern BasePersistentData Internal_FileCreate(string fileName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern BasePersistentData Internal_FileCreateByName(string fileName);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern BasePersistentData Internal_FileCreateByName_Param(string fileName, string fileConfigName);
#endif

        #endregion
    }
}
