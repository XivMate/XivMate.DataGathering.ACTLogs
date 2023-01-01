using System.Collections.Generic;
using Newtonsoft.Json;
using XivMate.DataGatheering.ACTLogs.Forms.LazyExtensions;

namespace XivMate.DataGatheering.ACTLogs.Forms;

public class ACTLogSettings
{
    public List<ACTLogFile> ActLogFiles { get; set; } = new();
}

public class ACTLogFile
{
    public string FileName { get; set; }
    public long FileLength { get; set; }

    // Used for the data grid
    [JsonIgnore] public string FilesSize => FileLength.SizeSuffix();
    public ACTLogFileStatus ActLogFileStatus { get; set; }
}

public enum ACTLogFileStatus
{
    Unchecked,
    NoMatches,
    Matches,
    Exported,
    Changed
}