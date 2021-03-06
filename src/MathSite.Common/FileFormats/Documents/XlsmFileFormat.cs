﻿using System.Collections.Generic;

namespace MathSite.Common.FileFormats.Documents
{
    public class XlsmFileFormat : VendorFileFormatBase
    {
        public override string ContentType { get; } = "application/vnd.ms-excel.sheet.macroEnabled.12";

        public override IEnumerable<string> Extensions { get; } = new[] {".xlsm"};
    }
}