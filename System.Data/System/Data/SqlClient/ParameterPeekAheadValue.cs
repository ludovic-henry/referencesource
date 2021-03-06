//------------------------------------------------------------------------------
// <copyright file="ParameterPeekAheadValue.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <owner current="true" primary="true">[....]</owner>
// <owner current="true" primary="false">[....]</owner>
//------------------------------------------------------------------------------



namespace System.Data.SqlClient {

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Server;


    // simple storage to contain objects that must be generated prior to sending data, but
    //  that we cannot re-generate at the time of sending the data.  The entire purpose is
    //  to avoid long, complicated parameter lists that take every possible set of values.
    //  Instead, a single peekahead object is passed in, encapsulating whatever sets are needed.
    //
    //  Example:
    //      When processing IEnumerable<SqlDataRecord>, we need to obtain the enumerator and
    //      the first record during metadata generation (metadata is stored in the first record),
    //      but to properly stream the value, we can't ask the IEnumerable for these objects again
    //      when it's time to send the actual values.

    internal class ParameterPeekAheadValue {
        // Peekahead for IEnumerable<SqlDataRecord>
        internal IEnumerator<SqlDataRecord> Enumerator;
        internal SqlDataRecord              FirstRecord;
    }

}
