using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace XivMate.DataGathering.ACTLogs.Forms;

internal class LogFileBackgroundWorker : BackgroundWorker
{
    private readonly LogFileParser logFileParser = new();

    protected override void OnDoWork(DoWorkEventArgs e)
    {
        var request = e.Argument as LogFileProcessRequest;
        var files = request.ActLogFiles;
        var totalFiles = files.Count();

        for (var i = 0; i < totalFiles; i++)
        {
            var actFile = files[i];
            ReportProgress((int)(100 * ((double)i / totalFiles)), actFile);
            var didParseStuff = ProcessLogFile(Path.Combine(request.ActLogFileDirectory, actFile),
                Path.Combine(request.OutputDirectory, actFile));

            var result = new LogFileProcessResult
            {
                HasRelevantLogs = didParseStuff,
                LogFile = actFile
            };
            ReportProgress((int)(100 * ((double)i / totalFiles)), result);
        }

        ReportProgress(100);
    }

    private bool ProcessLogFile(string actFile, string requestOutputFile)
    {
        using var fs = new FileStream(actFile, FileMode.Open);
        using var fileStream = new StreamReader(fs);
        string line = null;
        var doWeCare = false;
        while ((line = fileStream.ReadLine()) != null)
            if (logFileParser.IsZoneChange(line) && logFileParser.IsZoneWeCareAbout(line))
            {
                doWeCare = true;
                break;
            }

        if (!doWeCare) return false;
        //Move back to the start
        fs.Position = 0;
        fileStream.DiscardBufferedData();

        //Parse log for realsies
        using var outputFileStream = new FileStream(Path.Combine(requestOutputFile), FileMode.Create);
        using var outputStream = new StreamWriter(outputFileStream);
        while ((line = fileStream.ReadLine()) != null)
        {
            if (logFileParser.IsZoneChange(line)) doWeCare = logFileParser.ShouldStartRecording(line);

            if (!doWeCare)
                continue;

            var outputLine = logFileParser.FilterLogLine(line);
            if (outputLine != null)
                outputStream.WriteLine(outputLine);
        }

        return true;
    }
}

internal class LogFileProcessRequest
{
    public string ActLogFileDirectory { get; set; }
    public string OutputDirectory { get; set; }
    public bool Compress { get; set; }
    public List<string> ActLogFiles { get; set; }
}

internal class LogFileProcessResult
{
    public string LogFile { get; set; }
    public bool HasRelevantLogs { get; set; }
}