using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CSVFileUpdater.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public FileUpdateUtility m_CSVUpdater;

            public FileUpdateUtility CSVUpdater
            {
                [DebuggerHidden]
                get
                {
                    m_CSVUpdater = MyForms.Create__Instance__(m_CSVUpdater);
                    return m_CSVUpdater;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_CSVUpdater)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_CSVUpdater);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FileUpdateUtilInfo m_CSVUpdaterInfo;

            public FileUpdateUtilInfo CSVUpdaterInfo
            {
                [DebuggerHidden]
                get
                {
                    m_CSVUpdaterInfo = MyForms.Create__Instance__(m_CSVUpdaterInfo);
                    return m_CSVUpdaterInfo;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_CSVUpdaterInfo)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_CSVUpdaterInfo);
                }
            }
        }
    }
}